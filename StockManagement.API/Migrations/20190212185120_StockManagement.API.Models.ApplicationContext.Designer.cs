﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockManagement.API.Models;

namespace StockManagement.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190212185120_StockManagement.API.Models.ApplicationContext")]
    partial class StockManagementAPIModelsApplicationContext
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.1-servicing-10028")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockManagement.API.Models.Action", b =>
                {
                    b.Property<int>("ActionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int?>("RoleID");

                    b.HasKey("ActionID");

                    b.HasIndex("RoleID");

                    b.ToTable("Action","dbo");

                    b.HasData(
                        new
                        {
                            ActionID = 1,
                            Description = "Action assigned to allow adding new users",
                            Name = "Can add users"
                        },
                        new
                        {
                            ActionID = 2,
                            Description = "Action assigned to allow editing users",
                            Name = "Can edit users"
                        },
                        new
                        {
                            ActionID = 3,
                            Description = "Action assigned to allow deleting users",
                            Name = "Can delete user"
                        },
                        new
                        {
                            ActionID = 4,
                            Description = "Action assigned to allow adding new stock",
                            Name = "Can Add stock"
                        },
                        new
                        {
                            ActionID = 5,
                            Description = "Action assigned to allow editing stock",
                            Name = "Can edit stock"
                        },
                        new
                        {
                            ActionID = 6,
                            Description = "Action assigned to allow deleting stock",
                            Name = "Can delete stock"
                        },
                        new
                        {
                            ActionID = 7,
                            Description = "Acton assigned to a allow adding new system actions",
                            Name = "Can add action"
                        });
                });

            modelBuilder.Entity("StockManagement.API.Models.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("RoleID");

                    b.ToTable("Role","dbo");

                    b.HasData(
                        new
                        {
                            RoleID = 1,
                            Description = "Role used by users that require admin access",
                            Name = "Admin"
                        },
                        new
                        {
                            RoleID = 2,
                            Description = "Role used by users that do basic application functions",
                            Name = "User"
                        },
                        new
                        {
                            RoleID = 3,
                            Description = "Role used by users that require access to stock",
                            Name = "StockController"
                        },
                        new
                        {
                            RoleID = 4,
                            Description = "Role used by users that require view only access on application",
                            Name = "Guest"
                        });
                });

            modelBuilder.Entity("StockManagement.API.Models.RoleAction", b =>
                {
                    b.Property<int>("RoleActionID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ActionID");

                    b.Property<int>("RoleID");

                    b.HasKey("RoleActionID");

                    b.HasIndex("ActionID");

                    b.HasIndex("RoleID");

                    b.ToTable("RoleAction");

                    b.HasData(
                        new
                        {
                            RoleActionID = 1,
                            ActionID = 1,
                            RoleID = 1
                        },
                        new
                        {
                            RoleActionID = 2,
                            ActionID = 2,
                            RoleID = 1
                        },
                        new
                        {
                            RoleActionID = 3,
                            ActionID = 3,
                            RoleID = 1
                        },
                        new
                        {
                            RoleActionID = 4,
                            ActionID = 4,
                            RoleID = 1
                        },
                        new
                        {
                            RoleActionID = 5,
                            ActionID = 5,
                            RoleID = 1
                        },
                        new
                        {
                            RoleActionID = 6,
                            ActionID = 6,
                            RoleID = 1
                        },
                        new
                        {
                            RoleActionID = 7,
                            ActionID = 7,
                            RoleID = 1
                        },
                        new
                        {
                            RoleActionID = 8,
                            ActionID = 2,
                            RoleID = 2
                        },
                        new
                        {
                            RoleActionID = 9,
                            ActionID = 5,
                            RoleID = 2
                        },
                        new
                        {
                            RoleActionID = 10,
                            ActionID = 4,
                            RoleID = 3
                        },
                        new
                        {
                            RoleActionID = 11,
                            ActionID = 5,
                            RoleID = 3
                        },
                        new
                        {
                            RoleActionID = 12,
                            ActionID = 6,
                            RoleID = 3
                        });
                });

            modelBuilder.Entity("StockManagement.API.Models.StockItem", b =>
                {
                    b.Property<int>("StockItemID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LastChangeByUserID");

                    b.Property<DateTime>("LastChangeDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,3)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("StockItemID");

                    b.HasIndex("LastChangeByUserID");

                    b.ToTable("StockItem","dbo");

                    b.HasData(
                        new
                        {
                            StockItemID = 1,
                            DateCreated = new DateTime(2017, 11, 12, 9, 10, 45, 0, DateTimeKind.Unspecified),
                            Description = "Short metal like piece shaped to a spoon",
                            IsActive = true,
                            LastChangeByUserID = 1,
                            LastChangeDate = new DateTime(2018, 1, 2, 15, 30, 22, 0, DateTimeKind.Unspecified),
                            Name = "Pap lepel",
                            Price = 25.65m,
                            Quantity = 500
                        });
                });

            modelBuilder.Entity("StockManagement.API.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime>("LastChangeDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("RoleID");

                    b.Property<string>("Telephone")
                        .HasColumnType("varchar(30)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.ToTable("User","dbo");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            DateOfBirth = new DateTime(2018, 1, 2, 15, 30, 45, 0, DateTimeKind.Unspecified),
                            Email = "glucas@email.co.za",
                            FirstName = "George",
                            IsActive = true,
                            LastChangeDate = new DateTime(2018, 1, 2, 15, 30, 45, 0, DateTimeKind.Unspecified),
                            LastName = "Lucas",
                            Password = "G@Lucas101",
                            RoleID = 1,
                            Telephone = "0129876123"
                        },
                        new
                        {
                            UserID = 2,
                            DateOfBirth = new DateTime(1982, 5, 22, 15, 30, 11, 0, DateTimeKind.Unspecified),
                            Email = "juan@marshan.co.za",
                            FirstName = "Juan",
                            IsActive = true,
                            LastChangeDate = new DateTime(2019, 1, 2, 15, 30, 30, 0, DateTimeKind.Unspecified),
                            LastName = "Buys",
                            Password = "juan@marshan.co.za",
                            RoleID = 3,
                            Telephone = "0415784120"
                        },
                        new
                        {
                            UserID = 3,
                            DateOfBirth = new DateTime(2018, 1, 2, 15, 30, 59, 0, DateTimeKind.Unspecified),
                            Email = "asmith@email.co.za",
                            FirstName = "Abigail",
                            IsActive = true,
                            LastChangeDate = new DateTime(2018, 11, 12, 9, 10, 1, 0, DateTimeKind.Unspecified),
                            LastName = "Smith",
                            Password = "G@Lucas101",
                            RoleID = 2,
                            Telephone = "0214758901"
                        });
                });

            modelBuilder.Entity("StockManagement.API.Models.Action", b =>
                {
                    b.HasOne("StockManagement.API.Models.Role")
                        .WithMany("Actions")
                        .HasForeignKey("RoleID");
                });

            modelBuilder.Entity("StockManagement.API.Models.RoleAction", b =>
                {
                    b.HasOne("StockManagement.API.Models.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("StockManagement.API.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StockManagement.API.Models.StockItem", b =>
                {
                    b.HasOne("StockManagement.API.Models.User", "User")
                        .WithMany("StockItems")
                        .HasForeignKey("LastChangeByUserID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("StockManagement.API.Models.User", b =>
                {
                    b.HasOne("StockManagement.API.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
