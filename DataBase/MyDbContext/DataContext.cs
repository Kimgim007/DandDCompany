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

        public DbSet<GameCharacter> GameCharacters { get; set; }
        public DbSet<GameRoom> GameRooms { get; set; }
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

                entityTypeBuilder.HasOne(q=>q.GameClass).WithMany(q=>q.GameCharacters).HasForeignKey(q=>q.GameCharacterId);
            });

            modelBuilder.Entity<GameRoom>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.GameRoomId);
            });

            modelBuilder.Entity<GameClass>(entityTypeBuilder =>
            {
                //entityTypeBuilder.HasKey(x => x.GameClassId);

                entityTypeBuilder.HasMany(q=>q.GameCharacters).WithOne(q=>q.GameClass).HasForeignKey(x=>x.GameClassId);
            });

            modelBuilder.Entity<GameAccount>(entityTypeBuilder =>
            {
                entityTypeBuilder.HasKey(x => x.GameAccountId);
                entityTypeBuilder.HasIndex(x => x.Email).IsUnique();
              
            });

          
        }
    }
}
