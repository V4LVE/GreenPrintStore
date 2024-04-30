using GreenPrint.Blazor.Models;

namespace GreenPrint.Blazor.Service.Intefaces
{
    public interface IItemService
    {

        /// <summary>
        /// Create an item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<Item> CreateItem(Item item);
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public Task<List<Item>> GetFeaturedItemsAsync();

        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public Task<List<Item>> GetAllItemsByCategory(int categoryId);

        /// <summary>
        /// Get item by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Task<Item> GetItemByIdAsync(int itemId);

        /// <summary>
        /// Get featured items by category
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public Task<List<Item>> GetFeaturedItemsByCategoryAsync(int categoryId);

        /// <summary>
        /// Patch an item
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="newitem"></param>
        /// <returns></returns>
        public Task<Item> UpdateShopAsync(int itemId, Item newitem);
    }
}
