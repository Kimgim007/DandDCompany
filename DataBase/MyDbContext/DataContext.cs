using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataBase.DbEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataBase.MyDbContext
{
    public class DataContext : DbContext
    {
        public DataContext() { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<GameClass> GameClasss { get; set; }  
        public DbSet<Account> Accounts { get; set; }
        public DbSet<CharacterRoom> CharacterRooms { get; set; }
      
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

            modelBuilder.Entity<Character>(entityTypeBuilder =>
            {             
                entityTypeBuilder.HasOne(q=>q.GameClass).WithMany(q=>q.Characters).HasForeignKey(q=>q.CharacterId);
            });

            modelBuilder.Entity<Room>(entityTypeBuilder =>
            {             
            });

            modelBuilder.Entity<GameClass>(entityTypeBuilder =>
            {               
                entityTypeBuilder.HasMany(q=>q.Characters).WithOne(q=>q.GameClass).HasForeignKey(x=>x.GameClassId);
            });

            modelBuilder.Entity<Account>(entityTypeBuilder =>
            {            
                entityTypeBuilder.HasIndex(x => x.Email).IsUnique();            
            });          
        }
    }
}
