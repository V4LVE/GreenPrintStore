using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.Service.Intefaces;
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
    }
}
