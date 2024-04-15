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
                        },
                        new
                        {
                            Id = 2,
                            City = "New Davemouth",
                            StreetName = "Schinner Forge",
                            StreetNumber = "24",
                            ZipCode = "21955"
                        },
                        new
                        {
                            Id = 3,
                            City = "West Ronnyshire",
                            StreetName = "Hayes Loaf",
                            StreetNumber = "89",
                            ZipCode = "53811"
                        },
                        new
                        {
                            Id = 4,
                            City = "Myrticechester",
                            StreetName = "Domenico Shoal",
                            StreetNumber = "43",
                            ZipCode = "28916"
                        },
                        new
                        {
                            Id = 5,
                            City = "North Deondrefort",
                            StreetName = "Loraine Street",
                            StreetNumber = "44",
                            ZipCode = "28306"
                        },
                        new
                        {
                            Id = 6,
                            City = "Ornside",
                            StreetName = "Leora Springs",
                            StreetNumber = "8",
                            ZipCode = "62995-4518"
                        },
                        new
                        {
                            Id = 7,
                            City = "West Maeshire",
                            StreetName = "Wilburn Fork",
                            StreetNumber = "41",
                            ZipCode = "57842"
                        },
                        new
                        {
                            Id = 8,
                            City = "Haileyside",
                            StreetName = "Nikolaus Motorway",
                            StreetNumber = "44",
                            ZipCode = "12470"
                        },
                        new
                        {
                            Id = 9,
                            City = "Pricebury",
                            StreetName = "Kutch Ranch",
                            StreetNumber = "77",
                            ZipCode = "18346-1301"
                        },
                        new
                        {
                            Id = 10,
                            City = "Wuckertburgh",
                            StreetName = "Lesley Corners",
                            StreetNumber = "27",
                            ZipCode = "89892-1161"
                        },
                        new
                        {
                            Id = 11,
                            City = "Olaton",
                            StreetName = "Powlowski View",
                            StreetNumber = "93",
                            ZipCode = "99833"
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

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

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
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            Email = "otto@rosenbaum.co.uk",
                            FirstName = "Tavares",
                            LastName = "Vandervort",
                            Phone = "(213)957-3902"
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            Email = "jammie_corkery@leannonpredovic.name",
                            FirstName = "Tad",
                            LastName = "Greenholt",
                            Phone = "153-635-7582"
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 4,
                            Email = "albin_bahringer@okon.uk",
                            FirstName = "Josiah",
                            LastName = "Johnson",
                            Phone = "505-699-9576 x148"
                        },
                        new
                        {
                            Id = 5,
                            AddressId = 5,
                            Email = "rico@kuphal.com",
                            FirstName = "Marcelo",
                            LastName = "Altenwerth",
                            Phone = "(925)867-9543 x98419"
                        },
                        new
                        {
                            Id = 6,
                            AddressId = 6,
                            Email = "jarret@carroll.name",
                            FirstName = "Kody",
                            LastName = "Watsica",
                            Phone = "(721)600-2187 x208"
                        },
                        new
                        {
                            Id = 7,
                            AddressId = 7,
                            Email = "ian@stroman.biz",
                            FirstName = "Thelma",
                            LastName = "Thompson",
                            Phone = "528.474.0590 x1794"
                        },
                        new
                        {
                            Id = 8,
                            AddressId = 8,
                            Email = "frank.roberts@schumm.ca",
                            FirstName = "Anika",
                            LastName = "Upton",
                            Phone = "099.854.6841"
                        },
                        new
                        {
                            Id = 9,
                            AddressId = 9,
                            Email = "tyson@murray.com",
                            FirstName = "Porter",
                            LastName = "Daniel",
                            Phone = "1-294-426-2695"
                        },
                        new
                        {
                            Id = 10,
                            AddressId = 10,
                            Email = "kyler@emmerich.ca",
                            FirstName = "Nikita",
                            LastName = "Brown",
                            Phone = "(682)348-3861 x1598"
                        },
                        new
                        {
                            Id = 11,
                            AddressId = 11,
                            Email = "katrine_strosin@hermistontrantow.us",
                            FirstName = "Maria",
                            LastName = "Hammes",
                            Phone = "530.813.0972"
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

            modelBuilder.Entity("GreenPrint.Repository.Entities.ItemImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.ToTable("Images");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "1.png",
                            ItemId = 1
                        },
                        new
                        {
                            Id = 2,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "2.png",
                            ItemId = 2
                        },
                        new
                        {
                            Id = 3,
                            DateCreated = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "3.png",
                            ItemId = 3
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

                    b.HasIndex("Roleid");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "alex802c@gmail.com",
                            Password = "Pwrvol901",
                            Roleid = 3
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 2,
                            Email = "otto@rosenbaum.co.uk",
                            Password = "Password",
                            Roleid = 1
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 3,
                            Email = "jammie_corkery@leannonpredovic.name",
                            Password = "Password",
                            Roleid = 3
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 4,
                            Email = "albin_bahringer@okon.uk",
                            Password = "Password",
                            Roleid = 2
                        },
                        new
                        {
                            Id = 5,
                            CustomerId = 5,
                            Email = "rico@kuphal.com",
                            Password = "Password",
                            Roleid = 3
                        },
                        new
                        {
                            Id = 6,
                            CustomerId = 6,
                            Email = "jarret@carroll.name",
                            Password = "Password",
                            Roleid = 3
                        },
                        new
                        {
                            Id = 7,
                            CustomerId = 7,
                            Email = "ian@stroman.biz",
                            Password = "Password",
                            Roleid = 3
                        },
                        new
                        {
                            Id = 8,
                            CustomerId = 8,
                            Email = "frank.roberts@schumm.ca",
                            Password = "Password",
                            Roleid = 2
                        },
                        new
                        {
                            Id = 9,
                            CustomerId = 9,
                            Email = "tyson@murray.com",
                            Password = "Password",
                            Roleid = 3
                        },
                        new
                        {
                            Id = 10,
                            CustomerId = 10,
                            Email = "kyler@emmerich.ca",
                            Password = "Password",
                            Roleid = 1
                        },
                        new
                        {
                            Id = 11,
                            CustomerId = 11,
                            Email = "katrine_strosin@hermistontrantow.us",
                            Password = "Password",
                            Roleid = 3
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

                    b.HasOne("GreenPrint.Repository.Entities.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("GreenPrint.Repository.Entities.Customer", "UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Address");

                    b.Navigation("User");
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

            modelBuilder.Entity("GreenPrint.Repository.Entities.ItemImage", b =>
                {
                    b.HasOne("GreenPrint.Repository.Entities.Item", "Item")
                        .WithMany("ItemImages")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");
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
                    b.HasOne("GreenPrint.Repository.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("Roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .WithMany("warehouseItems")
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
                });

            modelBuilder.Entity("GreenPrint.Repository.Entities.Item", b =>
                {
                    b.Navigation("ItemImages");

                    b.Navigation("warehouseItems");
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
                    b.Navigation("Customer");

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
