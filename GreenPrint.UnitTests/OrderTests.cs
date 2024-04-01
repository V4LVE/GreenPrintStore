using GreenPrint.Repository.Domain;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Services;
using GreenPrint.Services.Services;

namespace GreenPrint.UnitTests
{
    public class OrderTests
    {
        #region Setup
        private static StoreContext _context = new();
        private static MappingService _mappingService = new();

        // Services
        private AddressService _addressService = new(_context, _mappingService);
        private CategoryService _categoryService = new(_context, _mappingService);
        private CustomerService _customerService = new(_context, _mappingService);
        private ItemService _itemService = new(_context, _mappingService);
        private OrderService _orderService = new(_context, _mappingService);
        private RoleService _roleService = new(_context, _mappingService);
        private UserService _userService = new(_context, _mappingService);
        private WarehouseService _warehouseService = new(_context, _mappingService);
        private WarehouseItemService _warehouseItemService = new(_context, _mappingService);
        #endregion


        [Fact]
        public async Task CreateOrder()
        {
            // Arrange

            // Initialize basket
            List<ItemOrderDTO> basket = new();

            // Initialize order with customer
            OrderDTO newOrder = new()
            {
                OrderDate = DateTime.Now,
                Customer = await _customerService.GetByIdAsync(1),
            };

            // Create order and return it so we can work with it
            newOrder = await _orderService.CreateAndReturn(newOrder);

            ItemOrderDTO itemOrder = new()
            {
                Item = await _itemService.GetByIdAsync(1),
                Order = newOrder,
                Warehouse = await _warehouseService.GetByIdAsync(1),
                Quantity = 2
            };

            ItemOrderDTO itemOrder2 = new()
            {
                Item = await _itemService.GetByIdAsync(2),
                Order = newOrder,
                Warehouse = await _warehouseService.GetByIdAsync(1),
                Quantity = 1
            };

            basket.Add(itemOrder);
            basket.Add(itemOrder2);


        }
    }
}