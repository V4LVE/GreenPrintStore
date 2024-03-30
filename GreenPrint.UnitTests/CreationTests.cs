using GreenPrint.Repository.Domain;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Services;
using GreenPrint.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace GreenPrint.UnitTests
{
    public class CreationTests
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
        public async Task CreateAddress()
        {
            // Arrange
            var address = new AddressDTO
            {
                StreetName = "NigGade",
                StreetNumber = "2B",
                ZipCode = "6400",
                City = "Sønderborg"
            };

            // Act
            await _addressService.CreateAsync(address);
            
            var temp = await _addressService.GetByIdAsync(1);

            // Assert
            Assert.Equal(address.StreetName, temp.StreetName);
        }
    }
}