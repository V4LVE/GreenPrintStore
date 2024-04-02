using Dumpify;
using GreenPrint.Repository.Domain;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Services;
using GreenPrint.Services.Services;
using GreenPrint.UnitTests.TestTools;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Xunit.Abstractions;

namespace GreenPrint.UnitTests
{
    public class OrderTests
    {
        private readonly ITestOutputHelper output;

        public OrderTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        #region Setup
        private static MappingService _mappingService = new();
        #endregion


        [Fact]
        public async Task CreateOrder()
        {
            // Arrange

            #region Setup
            ContextCreator.RecreateDatabase();
            StoreContext context = ContextCreator.Create();

            // Service Injections
            CustomerService customerService = new(context, _mappingService);
            OrderService orderService = new(context, _mappingService);
            ItemOrderService _itemOrderService = new(context, _mappingService);
            WarehouseItemService _warehouseItemService = new(context, _mappingService);
            #endregion

            // Initialize basket
            List<ItemOrderDTO> basket = new();
            CustomerDTO customer = await customerService.GetByIdAsync(1);

            // Initialize order with customer
            OrderDTO newOrder = new()
            {
                OrderDate = DateTime.Now,
                CustomerId = customer.Id,
            };

            // Create order and return it so we can work with it
            newOrder = await orderService.CreateAndReturn(newOrder);

            ItemOrderDTO itemOrder = new()
            {
                ItemId = 1,
                OrderId = newOrder.Id,
                WarehouseId = 1,
                Quantity = 2
            };

            ItemOrderDTO itemOrder2 = new()
            {
                ItemId = 2,
                OrderId = newOrder.Id,
                WarehouseId = 1,
                Quantity = 1
            };


            basket.Add(itemOrder);
            basket.Add(itemOrder2);

            if (basket.Count != 0)
            {
                await _itemOrderService.CreateListAsync(basket);
            }
            foreach (var item in basket)
            {
                WarehouseItemDTO warehouseItem = await _warehouseItemService.GetByItemAndWarehouseId(item.WarehouseId, item.ItemId);
                warehouseItem.Quantity -= item.Quantity;
                await _warehouseItemService.UpdateAsync(warehouseItem);
            }

            // Act
            OrderDTO result = await orderService.GetByIdAsync(newOrder.Id);

            // Assert
            Assert.True(result.ItemOrders.Count > 0);
            Assert.Equal(result.Id, newOrder.Id);
            Assert.Equal(result.CustomerId, newOrder.CustomerId);

            System.Diagnostics.Trace.WriteLine(result.Dump());

            output.WriteLine(result.DumpText());
        }
    }
}