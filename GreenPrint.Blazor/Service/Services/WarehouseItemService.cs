using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.PatchExtensions;
using GreenPrint.Blazor.Service.Intefaces;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
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
        public async Task<WarehouseItem> GetByItemId(int WarehouseItemId)
        {
            var Request = $"/WarehouseItem/{WarehouseItemId}";

            return await _client.GetFromJsonAsync<WarehouseItem>(Request);
        }


        public async Task<bool> CheckStock(int itemId, int amount)
        {
            var Request = $"/WarehouseItem/item/stock/{itemId}/{amount}";

            return await _client.GetFromJsonAsync<bool>(Request);
        }

        public async Task<WarehouseItem> AddStock(WarehouseItem warehouseItem)
        {
            var response = await _client.PostAsJsonAsync("/WarehouseItem/create", warehouseItem);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<WarehouseItem>();
        }

        public async Task<WarehouseItem> UpdateWarehouseItem(WarehouseItem warehouseItem)
        {
            var oldItem = await GetByItemId(warehouseItem.Id);
            warehouseItem.Item = null;
            warehouseItem.Warehouse = null;

            JsonPatchDocument<WarehouseItem> document = oldItem.PatchModelW(warehouseItem);

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(document), System.Text.Encoding.UTF8, "application/json-patch+json");

            var request = new HttpRequestMessage(HttpMethod.Patch, $"/WarehouseItem/update/{warehouseItem.Id}") { Content = stringContent };

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<WarehouseItem>();
        }

        public async Task<WarehouseItem> GetByItemAndWarehouseId(int itemId, int warehouseId)
        {
            var Request = $"/WarehouseItem/{itemId}/{warehouseId}";

            return await _client.GetFromJsonAsync<WarehouseItem>(Request);
        }
    }
}
