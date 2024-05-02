using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.Service.Intefaces;
using System.Net.Http.Json;

namespace GreenPrint.Blazor.Service.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly HttpClient _client;

        public CustomerService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Customer> CreateCustomer(Customer Customer)
        {
            var response = await _client.PostAsJsonAsync("/Customer/create", Customer);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Customer>();
        }


    }
}
