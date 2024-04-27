using GreenPrint.Blazor.Models;

namespace GreenPrint.Blazor.Service.Intefaces
{
    public interface IItemService
    {
        /// <summary>
        /// Get all items
        /// </summary>
        /// <returns></returns>
        public Task<List<Item>> GetFeaturedItemsAsync();

        //public Task<List<Item>> GetFeaturedItemsByCategoryAsync(int categoryId);
    }
}
