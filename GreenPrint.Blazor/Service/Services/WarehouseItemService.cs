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
            //var Request = $"/WarehouseItem/item/{itemId}";
            var Request = $"/WarehouseItem/item/1";

            return await _client.GetFromJsonAsync<List<WarehouseItem>>(Request);
        }
    }
}
