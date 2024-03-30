using GreenPrint.Repository.Entities;
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
            #endregion
        }
    }
}
