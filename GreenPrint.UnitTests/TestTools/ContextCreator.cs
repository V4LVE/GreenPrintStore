using GreenPrint.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.UnitTests.TestTools
{
    public class ContextCreator
    {
        public static StoreContext Create()
        {
            DbContextOptionsBuilder<StoreContext> optionsBuilder = new DbContextOptionsBuilder<StoreContext>();

            optionsBuilder.UseInMemoryDatabase("TestDB");
            optionsBuilder.EnableSensitiveDataLogging();

            return new StoreContext(optionsBuilder.Options);
        }

        public static void RecreateDatabase()
        {
            using StoreContext context = Create();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();


        }
    }
}
