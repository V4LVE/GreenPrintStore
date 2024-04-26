using GreenPrint.Blazor.Models;

namespace GreenPrint.Blazor.Service.Intefaces
{
    public interface ICategoryService
    {

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public Task<List<Category>> GetAllCategoriesAsync();
    }
}
