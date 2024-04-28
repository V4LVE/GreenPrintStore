using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.Service.Intefaces;
using System.Net.Http.Json;

namespace GreenPrint.Blazor.Service.Services
{
    public class ImageService : IImageService
    {
        private readonly HttpClient _client;

        public ImageService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<ItemImage>> GetAllByItemId(int itemId)
        {
            var Request = $"/Image/GetImagesById/{itemId}";

            return await _client.GetFromJsonAsync<List<ItemImage>>(Request);
        }
    }
}
