using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataBase.DbEntity;
using Microsoft.EntityFrameworkCore;

namespace DataBase.MyDbContext
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Class> Classs { get; set; }  
        public DbSet<PersonalPage> PersonalPages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionsString = "Server=(localdb)\\MSSQLLocalDB;Database=DandDCompany;Trusted_Connection=True;";

            if (optionsBuilder.IsConfigured == false)
            {
                optionsBuilder.UseSqlServer(connectionsString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Player>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.PlayerId);

            });

            modelBuilder.Entity<Group>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.GroupId);

            });

            modelBuilder.Entity<Class>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.ClassId);

            });

            modelBuilder.Entity<PersonalPage>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.PersonalPageId);
              

            });

        }
    }
}
