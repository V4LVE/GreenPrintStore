using Dumpify;
using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Enums;
using GreenPrint.Repository.Paging;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Services;
using GreenPrint.Services.Services;
using GreenPrint.UnitTests.TestTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace GreenPrint.UnitTests
{
    public class GetTests
    {
        private readonly ITestOutputHelper output;

        public GetTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        #region Setup
        private static MappingService _mappingService = new();
        #endregion

        [Fact]
        public async Task GetSimpleItemById()
        {
            //Arrange
            #region Setup
            StoreContext context = ContextCreator.Create();
            ContextCreator.RecreateDatabase(context);

            // Service Injections
            ItemService itemService = new(context, _mappingService);
            #endregion

            // Act
            ItemDTO result = await itemService.GetByIdAsync(1);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            
            output.WriteLine(result.DumpText());
        }

        [Fact]
        public async Task GetItemMultipage()
        {
            //Arrange
            #region Setup
            StoreContext context = ContextCreator.Create();
            ContextCreator.RecreateDatabase(context);

            // Service Injections
            ItemService itemService = new(context, _mappingService);
            #endregion

            PageOptions pageOptions = new()
            {
                PageNum = 1,
                PageSize = 1
            };

            PageOptions pageOptions2 = new()
            {
                PageNum = 2,
                PageSize = 1
            };

            // Act
            List<ItemDTO> resultP1 = await itemService.GetAllAsyncWithPaging(pageOptions);
            List<ItemDTO> resultP2 = await itemService.GetAllAsyncWithPaging(pageOptions2);

            //Assert
            Assert.True(resultP1.Count != 0);
            Assert.True(resultP2.Count != 0);
            Assert.NotEqual(resultP1[0].Id, resultP2[0].Id);

            output.WriteLine(resultP1.DumpText());
            output.WriteLine(resultP2.DumpText());
        }

        [Fact]
        public async Task GetItemsBySearch()
        {
            //Arrange
            #region Setup
            StoreContext context = ContextCreator.Create();
            ContextCreator.RecreateDatabase(context);

            // Service Injections
            ItemService itemService = new(context, _mappingService);
            #endregion

            // Act
            List<ItemDTO> result = await itemService.GetItemsBySearch("ELEGOO");

            //Assert
            Assert.True(result.Count > 0);
            Assert.Contains(result, x => x.ItemName.Contains("ELEGOO"));

            output.WriteLine(result.DumpText());
        }

        [Fact]
        public async Task GetItemsByCategory()
        {
            //Arrange
            #region Setup
            StoreContext context = ContextCreator.Create();
            ContextCreator.RecreateDatabase(context);

            // Service Injections
            ItemService itemService = new(context, _mappingService);
            #endregion

            // Act
            List<ItemDTO> result = await itemService.GetItemsbyCategory("Printers");

            //Assert
            Assert.True(result.Count > 0);
            Assert.Contains(result, x => x.Category.CategoryName == "Printers");

            output.WriteLine(result.DumpText());
        }

        [Fact]
        public async Task GetItemsBySorting()
        {
            //Arrange
            #region Setup
            StoreContext context = ContextCreator.Create();
            ContextCreator.RecreateDatabase(context);

            // Service Injections
            ItemService itemService = new(context, _mappingService);
            #endregion

            PageOptions pageOptions = new();

            // Act
            List<ItemDTO> result = await itemService.GetAllAsyncWithPaging(pageOptions, OrderByOptionsItem.PriceAsc);

            //Assert
            Assert.True(result.Count > 0);

            output.WriteLine(result.DumpText());
        }
    }
}