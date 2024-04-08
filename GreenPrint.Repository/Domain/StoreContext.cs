using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Domain
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }
        public StoreContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlServer("Server =COLSERVER\\COLDB; Database = GreenPrintStore;User Id=DBUser;Password=Pwrvol901;TrustServerCertificate=True;"); // Desktop DB
                optionsBuilder.UseSqlServer("Server =ALEX_PC\\SQLEXPRESS; Database = GreenPrintStore; Trusted_Connection = True;TrustServerCertificate=True; "); // Laptop DB
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseLoggerFactory(new ServiceCollection()
                              .AddLogging(builder => builder.AddConsole()
                                                            .AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information))
                               .BuildServiceProvider().GetService<ILoggerFactory>());
            }

            base.OnConfiguring(optionsBuilder);
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

            // Address
            modelBuilder.Entity<Address>().HasData(
                               new Address
                               {
                                   Id = 1,
                                   StreetName = "JutlandStreet",
                                   StreetNumber = "69B",
                                   ZipCode = "6400",
                                   City = "Sønderborg"
                               }
                                              );

            // Warehouse
            modelBuilder.Entity<Warehouse>().HasData(
                new Warehouse
                {
                    Id = 1,
                    WarehouseName = "Warehouse",
                    AddressId = 1,
                    Items = new()
                }
                );

            // Warehouse items
            modelBuilder.Entity<WarehouseItem>().HasData(
                new WarehouseItem { Id = 1, WarehouseId = 1, ItemId = 1, Quantity = 10 },
                new WarehouseItem { Id = 2, WarehouseId = 1, ItemId = 2, Quantity = 5 },
                new WarehouseItem { Id = 3, WarehouseId = 1, ItemId = 3, Quantity = 100 }
                );

            // Customer
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                { Id = 1, FirstName = "John", LastName = "Doe", AddressId = 1, Email = "JohnnyD@69420.com", Phone = "69696969" }
                );

            // User
            modelBuilder.Entity<User>().HasData(
                               new User
                               {
                                   Id = 1,
                                   Email = "alex802c@gmail.com",
                                   Password = "Pwrvol901",
                                   CustomerId = 1,
                                   Roleid = 3
                               }
                          );
            #endregion

            // Relationships
            #region ItemOrder
            modelBuilder.Entity<ItemOrder>()
                .HasOne(io => io.Warehouse).WithMany(w => w.ItemOrders).HasForeignKey(io => io.WarehouseId).OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<ItemOrder>()
                .Property(io => io.Status).HasDefaultValue(OrderStatusEnum.Created);
            #endregion

            #region Warehouse
            modelBuilder.Entity<Warehouse>()
                .HasMany(w => w.ItemOrders).WithOne(io => io.Warehouse);
            #endregion

            #region Session
            modelBuilder.Entity<Session>()
                .HasOne(s => s.User).WithOne(u => u.Session).HasForeignKey<Session>(s => s.UserId).OnDelete(DeleteBehavior.NoAction);
            #endregion
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseItem> WarehouseItems { get; set; }
        public DbSet<ItemOrder> ItemOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Session> Sessions { get; set; }

    }
}
