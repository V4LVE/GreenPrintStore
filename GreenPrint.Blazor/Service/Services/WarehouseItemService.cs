using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.Service.Intefaces;
using System.Net.Http.Json;

namespace GreenPrint.Blazor.Service.Services
{
    public class WarehouseItemService : IWarehouseItemService
    {
        private readonly HttpClient _client;

        public WarehouseItemService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<WarehouseItem>> GetAllByByItemId(int itemId)
        {
            var Request = $"/WarehouseItem/item/{itemId}";

            return await _client.GetFromJsonAsync<List<WarehouseItem>>(Request);
        }

        public async Task<bool> CheckStock(int itemId, int amount)
        {
            var Request = $"/WarehouseItem/item/stock/{itemId}/{amount}";

            return await _client.GetFromJsonAsync<bool>(Request);
        }
    }
}
