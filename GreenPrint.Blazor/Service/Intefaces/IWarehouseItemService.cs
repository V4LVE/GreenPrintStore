using GreenPrint.Blazor.Models;

namespace GreenPrint.Blazor.Service.Intefaces
{
    public interface IWarehouseItemService
    {

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public Task<List<WarehouseItem>> GetAllByByItemId(int itemId);
    }
}
