using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
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

        public AddressDTO Address { get; set; }
        public CustomerDTO Customer { get; set; }
        public UserDTO User { get; set; }
        public WarehouseDTO Warehouse { get; set; }

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
            AddressDTO result = await _addressService.CreateAndReturn(address);
            
            var temp = await _addressService.GetByIdAsync(result.Id);

            // Assert
            Assert.Equal(address.StreetName, temp.StreetName);
            Address = temp;
        }

        [Fact]
        public async Task CreateCustomer()
        {
            Address = await _addressService.GetByIdAsync(1);

            // Arrange
            var customer = new CustomerDTO
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "JD@John.Doe",
                Phone = "12345678",
                AddressId = Address.Id
            };

            // Act
            CustomerDTO result = await _customerService.CreateAndReturn(customer);
            
            var temp = await _customerService.GetByIdAsync(result.Id);

            // Assert
            Assert.Equal(result.Id, temp.Id);
            Customer = temp;
        }

        [Fact]
        public async Task CreateUser()
        {
            var role = await _roleService.GetByIdAsync(1);
            this.Customer = await _customerService.GetByIdAsync(1);

            // Arrange
            var user = new UserDTO
            {
                Password = "Password",
                Email = "JohnDoe@John.Doe",
                Roleid = role.Id,
                CustomerId = Customer.Id
            };

            // Act
            UserDTO result = await _userService.CreateAndReturn(user);

            var temp = await _userService.GetByIdAsync(result.Id);

            // Assert
            Assert.Equal(result.Email, temp.Email);
            User = temp;
        }

    }
}