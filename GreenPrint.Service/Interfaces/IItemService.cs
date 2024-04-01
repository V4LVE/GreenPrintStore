using GreenPrint.Repository.Entities;
using GreenPrint.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Interfaces
{
    public interface IItemService : IGenericService<ItemDTO>
    {
        /// <summary>
        /// Get all items by category
        /// </summary>
        /// <returns></returns>
        Task<List<Item>> GetItemsbyCategory(string category);

        /// <summary>
        /// Get all items by search query
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<List<Item>> GetItemsBySearch(string searchQuery);
    }
}
