using GreenPrint.Repository.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.UnitTests.TestTools
{
    public class ContextCreator
    {
        public static StoreContext Create([CallerMemberName] string name = "")
        {
            DbContextOptionsBuilder<StoreContext> optionsBuilder = new DbContextOptionsBuilder<StoreContext>();

            optionsBuilder.UseInMemoryDatabase(name);
            optionsBuilder.EnableSensitiveDataLogging();

            return new StoreContext(optionsBuilder.Options);
        }

        public static void RecreateDatabase(StoreContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
