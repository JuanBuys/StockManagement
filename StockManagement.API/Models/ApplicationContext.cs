using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockManagement.API.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Apply configurations for entity

            modelBuilder
                .ApplyConfiguration(new ActionConfiguration())
                .ApplyConfiguration(new RoleConfiguration())
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new StockItemConfiguration());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Seed();
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StockItem> StockItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    }

    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Set configuration for entity
            builder.ToTable("User", "dbo");

            // Set key for entity
            builder.HasKey(p => p.UserID);

            // Set configuration for columns
            builder.Property(p => p.FirstName).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.LastName).HasColumnType("varchar(100)");
            builder.Property(p => p.Password).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Email).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Telephone).HasColumnType("varchar(30)");
            builder.Property(p => p.DateOfBirth).HasColumnType("date");
            builder.Property(p => p.IsActive).HasColumnType("bit").IsRequired();

            // Columns with generated value on add or update
            builder.Property(p => p.LastChangeDate).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();
        }
    }

    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            // Set configuration for entity
            builder.ToTable("Role", "dbo");

            // Set key for entity
            builder.HasKey(p => p.RoleID);

            // Set configuration for columns
            builder.Property(p => p.Name).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("varchar(100)");

        }
    }

    public class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            // Set configuration for entity
            builder.ToTable("Action", "dbo");

            // Set key for entity
            builder.HasKey(p => p.ActionID);

            // Set configuration for columns
            builder.Property(p => p.Name).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("varchar(100)");

        }
    }

    public class StockItemConfiguration : IEntityTypeConfiguration<StockItem>
    {
        public void Configure(EntityTypeBuilder<StockItem> builder)
        {
            // Set configuration for entity
            builder.ToTable("StockItem", "dbo");

            // Set key for entity
            builder.HasKey(p => p.StockItemID);

            // Set configuration for columns
            builder.Property(p => p.Name).HasColumnType("varchar(100)").IsRequired();
            builder.Property(p => p.Description).HasColumnType("varchar(500)");
            builder.Property(p => p.Price).HasColumnType("decimal(18,3)").IsRequired();
            builder.Property(p => p.Quantity).HasColumnType("int").IsRequired();
            builder.Property(p => p.IsActive).HasColumnType("bit").IsRequired();

            // Columns with generated value on add or update
            builder.Property(p => p.LastChangeDate).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()").ValueGeneratedOnAddOrUpdate();

            // Columns with generated value on add or update
            builder.Property(p => p.DateCreated).HasColumnType("datetime").IsRequired().HasDefaultValueSql("GETDATE()").ValueGeneratedOnAdd();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
            new Role
            {
                RoleID = 1,
                Name = "Admin",
                Description = "Role used by users that require admin access"
            },
            new Role
            {
                RoleID = 2,
                Name = "User",
                Description = "Role used by users that do basic application functions"
            },
            new Role
            {
                RoleID = 3,
                Name = "StockController",
                Description = "Role used by users that require access to stock"
            },
            new Role
            {
                RoleID = 4,
                Name = "Guest",
                Description = "Role used by users that require view only access on application"
            });

            modelBuilder.Entity<Action>().HasData(
            new Action
            {
                ActionID = 1,
                Name = "Can add users",
                Description = "Action assigned to allow adding new users"
            },
            new Action
            {
                ActionID = 2,
                Name = "Can edit users",
                Description = "Action assigned to allow editing users"
            },
            new Action
            {
                ActionID = 3,
                Name = "Can delete user",
                Description = "Action assigned to allow deleting users"
            },
            new Action
            {
                ActionID = 4,
                Name = "Can Add stock",
                Description = "Action assigned to allow adding new stock"
            },
            new Action
            {
                ActionID = 5,
                Name = "Can edit stock",
                Description = "Action assigned to allow editing stock"
            },
            new Action
            {
                ActionID = 6,
                Name = "Can delete stock",
                Description = "Action assigned to allow deleting stock"
            },
            new Action
            {
                ActionID = 7,
                Name = "Can add action",
                Description = "Acton assigned to a allow adding new system actions"
            });
            modelBuilder.Entity<RoleAction>().HasData(
            new RoleAction
            {
                RoleActionID = 1,
                RoleID = 1,
                ActionID = 1
            },
            new RoleAction
            {
                RoleActionID = 2,
                RoleID = 1,
                ActionID = 2
            },
            new RoleAction
            {
                RoleActionID = 3,
                RoleID = 1,
                ActionID = 3
            },
            new RoleAction
            {
                RoleActionID = 4,
                RoleID = 1,
                ActionID = 4
            },
            new RoleAction
            {
                RoleActionID = 5,
                RoleID = 1,
                ActionID = 5
            },
            new RoleAction
            {
                RoleActionID = 6,
                RoleID = 1,
                ActionID = 6
            },
            new RoleAction
            {
                RoleActionID = 7,
                RoleID = 1,
                ActionID = 7
            },
            new RoleAction
            {
                RoleActionID = 8,
                RoleID = 2,
                ActionID = 2
            },
            new RoleAction
            {
                RoleActionID = 9,
                RoleID = 2,
                ActionID = 5
            },
            new RoleAction
            {
                RoleActionID = 10,
                RoleID = 3,
                ActionID = 4
            },
            new RoleAction
            {
                RoleActionID = 11,
                RoleID = 3,
                ActionID = 5
            },
            new RoleAction
            {
                RoleActionID = 12,
                RoleID = 3,
                ActionID = 6
            });

            modelBuilder.Entity<User>().HasData(
            new User
            {
                UserID = 1,
                FirstName = "George",
                LastName = "Lucas",
                Password = "G@Lucas101",
                Email = "glucas@email.co.za",
                DateOfBirth = Convert.ToDateTime("2018-01-02 15:30:45"),
                Telephone = "0129876123",
                RoleID = 1,
                LastChangeDate = Convert.ToDateTime("2018-01-02 15:30:45"),
                IsActive = true
            },
            new User
            {
                UserID = 2,
                FirstName = "Juan",
                LastName = "Buys",
                Password = "juan@marshan.co.za",
                Email = "juan@marshan.co.za",
                DateOfBirth = Convert.ToDateTime("1982-05-22 15:30:11"),
                Telephone = "0415784120",
                RoleID = 3,
                LastChangeDate = Convert.ToDateTime("2019-01-02 15:30:30"),
                IsActive = true
            },
            new User
            {
                UserID = 3,
                FirstName = "Abigail",
                LastName = "Smith",
                Password = "G@Lucas101",
                Email = "asmith@email.co.za",
                DateOfBirth = Convert.ToDateTime("2018-01-02 15:30:59"),
                Telephone = "0214758901",
                RoleID = 2,
                LastChangeDate = Convert.ToDateTime("2018-11-12 09:10:01"),
                IsActive = true
            });

            modelBuilder.Entity<StockItem>().HasData(
            new StockItem
            {
                StockItemID = 1,
                Name = "Pap lepel",
                Description = "Short metal like piece shaped to a spoon",
                Price = 25.65m,
                Quantity = 500,
                IsActive = true,
                LastChangeByUserID = 1,
                DateCreated = Convert.ToDateTime("2017-11-12 09:10:45"),
                LastChangeDate = Convert.ToDateTime("2018-01-02 15:30:22"),

            });
        }
    }
}