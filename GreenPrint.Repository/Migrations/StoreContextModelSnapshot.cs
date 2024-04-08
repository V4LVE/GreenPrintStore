﻿// <auto-generated />
using System;
using GreenPrint.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenPrint.Repository.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GreenPrint.Repository.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Sønderborg",
                            StreetName = "JutlandStreet",
                            StreetNumber = "69B",
                            ZipCode = "6400"
                        });
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Printers"
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Filament"
                        },
                        new
                        {
                            Id = 3,
                            CategoryName = "Misc"
                        });
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            Email = "JohnnyD@69420.com",
                            FirstName = "John",
                            LastName = "Doe",
                            Phone = "69696969"
                        });
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "A good cheap 3D Printer",
                            ItemName = "ELEGOO Neptune 4 Pro",
                            Price = 2250.0
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Description = "A great but expensive 3D printer",
                            ItemName = "Bambulab X1 Carbon",
                            Price = 8500.0
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "A material for printing",
                            ItemName = "Sort PLA 1Kg",
                            Price = 150.0
                        });
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.ItemOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("ItemOrders");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Customer"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "StoreManager"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "SuperAdmin"
                        });
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Session", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("SessionToken")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Roleid")
                        .HasColumnType("int");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique()
                        .HasFilter("[CustomerId] IS NOT NULL");

                    b.HasIndex("Roleid");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 1,
                            Email = "JohnnyD@69420.com",
                            Password = "Password",
                            Roleid = 1
                        });
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("WarehouseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Warehouses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            WarehouseName = "Warehouse"
                        });
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.WarehouseItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("WarehouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("WarehouseId");

                    b.ToTable("WarehouseItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemId = 1,
                            Quantity = 10,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 2,
                            ItemId = 2,
                            Quantity = 5,
                            WarehouseId = 1
                        },
                        new
                        {
                            Id = 3,
                            ItemId = 3,
                            Quantity = 100,
                            WarehouseId = 1
                        });
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Customer", b =>
                {
                    b.HasOne("GreenPrint.Repository.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Item", b =>
                {
                    b.HasOne("GreenPrint.Repository.Entities.Category", "Category")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.ItemOrder", b =>
                {
                    b.HasOne("GreenPrint.Repository.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenPrint.Repository.Entities.Order", "Order")
                        .WithMany("ItemOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenPrint.Repository.Entities.Warehouse", "Warehouse")
                        .WithMany("ItemOrders")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.ClientNoAction)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Order", b =>
                {
                    b.HasOne("GreenPrint.Repository.Entities.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Session", b =>
                {
                    b.HasOne("GreenPrint.Repository.Entities.User", "User")
                        .WithOne("Session")
                        .HasForeignKey("GreenPrint.Repository.Entities.Session", "UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.User", b =>
                {
                    b.HasOne("GreenPrint.Repository.Entities.Customer", "Customer")
                        .WithOne("User")
                        .HasForeignKey("GreenPrint.Repository.Entities.User", "CustomerId");

                    b.HasOne("GreenPrint.Repository.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("Roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Warehouse", b =>
                {
                    b.HasOne("GreenPrint.Repository.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.WarehouseItem", b =>
                {
                    b.HasOne("GreenPrint.Repository.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenPrint.Repository.Entities.Warehouse", "Warehouse")
                        .WithMany("Items")
                        .HasForeignKey("WarehouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Category", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Customer", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Order", b =>
                {
                    b.Navigation("ItemOrders");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.User", b =>
                {
                    b.Navigation("Session");
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Warehouse", b =>
                {
                    b.Navigation("ItemOrders");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
