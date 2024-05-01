using GreenPrint.Blazor.Models;

namespace GreenPrint.Blazor.Service.Intefaces
{
    public interface IWarehouseService
    {
        /// <summary>
        /// Get all warehouses
        /// </summary>
        /// <returns></returns>
        public Task<List<Warehouse>> GetAllWarehouses();
    }
}
