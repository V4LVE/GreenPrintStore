using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.Service.Intefaces;
using System.Net.Http.Json;

namespace GreenPrint.Blazor.Service.Services
{
    public class ItemOrderService : IItemOrderService
    {

        private readonly HttpClient _client;

        public ItemOrderService(HttpClient client)
        {
            _client = client;
        }

        public async Task<HttpContent> CreateItemOrders(List<ItemOrder> ItemOrders)
        {
            var response = await _client.PostAsJsonAsync("/ItemOrder/create", ItemOrders);

            return response.Content;
        }


    }
}
