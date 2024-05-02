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
        /// Get the warehouse item by item and warehouse id
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        public Task<WarehouseItem> GetByItemAndWarehouseId(int itemId, int warehouseId);

        /// <summary>
        /// Updates a warehouse item
        /// </summary>
        /// <param name="warehouseItem"></param>
        /// <returns></returns>
        public Task<WarehouseItem> UpdateWarehouseItem(WarehouseItem warehouseItem);

        /// <summary>
        /// Check if an item is in stock
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="amount"></param>
        /// <returns>true/false</returns>
        public Task<bool> CheckStock(int itemId, int amount);

        /// <summary>
        /// Add stock to an item
        /// </summary>
        /// <param name="warehouseItem"></param>
        /// <returns></returns>
        public Task<WarehouseItem> AddStock(WarehouseItem warehouseItem);
    }
}
