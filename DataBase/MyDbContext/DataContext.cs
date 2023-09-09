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

        public DbSet<GameCharacter> GameCharacters { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GameClass> GameClasss { get; set; }  
        public DbSet<GameAccount> GameAccounts { get; set; }

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

            modelBuilder.Entity<GameCharacter>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.GameCharacterId);
            });

            modelBuilder.Entity<Group>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.GroupId);
            });

            modelBuilder.Entity<GameClass>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.GameClassId);


            });

            modelBuilder.Entity<GameAccount>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.GameAccountId);
              
            });

        }
    }
}
