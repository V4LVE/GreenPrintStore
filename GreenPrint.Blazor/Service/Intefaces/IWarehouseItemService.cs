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

        /// <summary>
        /// Check if an item is in stock
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="amount"></param>
        /// <returns>true/false</returns>
        public Task<bool> CheckStock(int itemId, int amount);
    }
}
