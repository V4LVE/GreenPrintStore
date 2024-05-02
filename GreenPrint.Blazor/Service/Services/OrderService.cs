using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.Service.Intefaces;
using System.Net.Http.Json;

namespace GreenPrint.Blazor.Service.Services
{
    public class OrderService : IOrderService
    {

        private readonly HttpClient _client;

        public OrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            var Request = $"/Order/{orderId}";

            return await _client.GetFromJsonAsync<Order>(Request);
        }

        public async Task<Order> CreateOrder(Order Order)
        {
            var response = await _client.PostAsJsonAsync("/Order/create", Order);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Order>();
        }


    }
}
