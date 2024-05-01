using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.Service.Intefaces;
using System.Net.Http.Json;

namespace GreenPrint.Blazor.Service.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly HttpClient _client;

        public WarehouseService(HttpClient client)
        {
            _client = client;
        }

        public async Task<List<Warehouse>> GetAllWarehouses()
        {
            var Request = $"/Warehouses";

            return await _client.GetFromJsonAsync<List<Warehouse>>(Request);
        }
    }
}
