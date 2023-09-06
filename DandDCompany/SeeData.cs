using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

public static class SeedData
{
 
    
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        await EnsureRolesAsync(roleManager);
        await EnsureAdminUserAsync(userManager);
    }

    private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
    {
        string[] roles = { "Admin", "User" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

    private static async Task EnsureAdminUserAsync(UserManager<IdentityUser> userManager)
    {
        try
        {
            var adminUserName = "Admin@gmail.com";
            var adminPassword = "Gumennnik007!";
            var adminEmail = "Admin@gmail.com";

            var existingAdmin = await userManager.FindByNameAsync(adminUserName);

            if (existingAdmin == null)
            {
                var adminUser = new IdentityUser
                {
                    UserName = adminUserName,
                    Email = adminEmail
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    adminUser.EmailConfirmed = true;
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
                else
                {
                    var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                    Console.WriteLine($"Failed to create Admin user. Errors: {errors}");
                    throw new Exception($"Failed to create Admin user. Errors: {errors}");
                }
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"An error occurred while creating the Admin user: {ex}");
            throw;
        }
        
    }
}
