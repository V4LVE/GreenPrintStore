using Dumpify;
using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Services;
using GreenPrint.Services.Services;
using GreenPrint.UnitTests.TestTools;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace GreenPrint.UnitTests
{
    public class CreationTests
    {
        private readonly ITestOutputHelper output;

        public CreationTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        #region Setup
        private static MappingService _mappingService = new();

        #endregion


        [Fact]
        public async Task CreateAddress()
        {
            #region Setup
            StoreContext context = ContextCreator.Create();
            ContextCreator.RecreateDatabase(context);

            // Service Injections
            AddressService addressService = new(context, _mappingService);
            #endregion

            // Arrange
            var newAddress = new AddressDTO
            {
                StreetName = "NigGade",
                StreetNumber = "2B",
                ZipCode = "6400",
                City = "Sønderborg"
            };

            // Act
            newAddress = await addressService.CreateAndReturn(newAddress);

            AddressDTO result = await addressService.GetByIdAsync(newAddress.Id);

            // Assert
            Assert.Equal(newAddress.StreetName, result.StreetName);
            Assert.Equal(newAddress.StreetNumber, result.StreetNumber);
            Assert.Equal(newAddress.Id, result.Id);

            output.WriteLine(result.DumpText());
        }

        [Fact]
        public async Task CreateCustomer()
        {
            #region Setup
            StoreContext context = ContextCreator.Create();
            ContextCreator.RecreateDatabase(context);

            // Service Injections
            CustomerService customerService = new(context, _mappingService);
            #endregion


            // Arrange
            var newCustomer = new CustomerDTO
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "JD@John.Doe",
                Phone = "12345678",
                AddressId = 1
            };

            // Act
            newCustomer = await customerService.CreateAndReturn(newCustomer);
            
            CustomerDTO result = await customerService.GetByIdAsync(newCustomer.Id);

            // Assert
            Assert.Equal(result.Id, newCustomer.Id);
            Assert.Equal(result.FirstName, newCustomer.FirstName);
            Assert.Equal(result.LastName, newCustomer.LastName);

            output.WriteLine(result.DumpText());
        }

        [Fact]
        public async Task CreateUser()
        {
            #region Setup
            StoreContext context = ContextCreator.Create();
            ContextCreator.RecreateDatabase(context);

            // Service Injections
            UserService userService = new(context, _mappingService);
            #endregion

            // Arrange
            var newUser = new UserDTO
            {
                Password = "Password",
                Email = "JohnDoe@John.Doe",
                Roleid = 1,
                CustomerId = 1
            };

            // Act
            newUser = await userService.CreateAndReturn(newUser);

            UserDTO result = await userService.GetByIdAsync(newUser.Id);

            // Assert
            Assert.Equal(result.Email, newUser.Email);
            Assert.Equal(result.Password, newUser.Password);
            Assert.Equal(result.Id, newUser.Id);

            output.WriteLine(result.DumpText());
        }

    }
}