using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.PatchExtensions;
using GreenPrint.Blazor.Service.Intefaces;
using Microsoft.AspNetCore.JsonPatch;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace GreenPrint.Blazor.Service.Services
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _client;

        public ItemService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Item>> GetFeaturedItemsAsync()
        {
            var Request = "/Items/GetFeaturedItems";

            return await _client.GetFromJsonAsync<List<Item>>(Request);
        }

        public async Task<List<Item>> GetAllItemsByCategory(int categoryId)
        {
            var Request = $"/Items/GetItemsByCategory/{categoryId}";

            return await _client.GetFromJsonAsync<List<Item>>(Request);
        }

        public async Task<List<Item>> GetFeaturedItemsByCategoryAsync(int categoryId)
        {
            var Request = $"/Items/GetFeaturedItemsByCategory/{categoryId}/1/8";
            //var Request = $"/Items/GetFeaturedItemsByCategory/1/1/8";

            return await _client.GetFromJsonAsync<List<Item>>(Request);
        }

        public async Task<Item> GetItemByIdAsync(int itemId)
        {
            var Request = $"/Item/{itemId}";

            return await _client.GetFromJsonAsync<Item>(Request);
        }

        public async Task<Item> UpdateShopAsync(int itemId, Item newitem)
        {
            var oldItem = await GetItemByIdAsync(itemId);

            JsonPatchDocument<Item> document = oldItem.PatchModel(newitem);

            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(document), System.Text.Encoding.UTF8, "application/json-patch+json");

            var request = new HttpRequestMessage(HttpMethod.Patch, $"/Item/update/{itemId}") { Content = stringContent };

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Item>();
        }
    }
}
