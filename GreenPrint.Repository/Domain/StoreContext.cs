﻿using GreenPrint.Repository.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Domain
{
    public class StoreContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Laptop
        //{
        //    optionsBuilder
        //        .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
        //        .UseSqlServer("Server =ALEX_PC\\SQLEXPRESS; Database = GreenPrintStore; Trusted_Connection = True;TrustServerCertificate=True; ");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // Desktop
        {
            optionsBuilder
                .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                .UseSqlServer("Server =COLSERVER\\COLDB; Database = GreenPrintStore;User Id=DBUser;Password=Pwrvol901;TrustServerCertificate=True; ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Data seeding

            // Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Customer" },
                new Role { Id = 2, RoleName = "StoreManager" },
                new Role { Id = 3, RoleName = "SuperAdmin" }
                );

            // Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, CategoryName = "Printers" },
                new Category { Id = 2, CategoryName = "Filament" },
                new Category { Id = 3, CategoryName = "Misc" }
                );

            // Items
            modelBuilder.Entity<Item>().HasData(
                new Item { Id = 1, ItemName = "ELEGOO Neptune 4 Pro", Description = "A good cheap 3D Printer", CategoryId = 1, Price = 2250 },
                new Item { Id = 2, ItemName = "Bambulab X1 Carbon", Description = "A great but expensive 3D printer", CategoryId = 1, Price = 8500 },
                new Item { Id = 3, ItemName = "Sort PLA 1Kg", Description = "A material for printing", CategoryId = 2, Price = 150 }
                );
            #endregion
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
