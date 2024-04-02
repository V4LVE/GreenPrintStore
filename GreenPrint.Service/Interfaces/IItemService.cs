using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using GreenPrint.Repository.Paging;
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
        /// Get all items with paging and sorting
        /// </summary>
        /// <param name="options"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<List<ItemDTO>> GetAllAsyncWithPaging(PageOptions options, OrderByOptionsItem order);

        /// <summary>
        /// Get all items by category
        /// </summary>
        /// <returns></returns>
        Task<List<ItemDTO>> GetItemsbyCategory(string category);

        /// <summary>
        /// Get all items by search query
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<List<ItemDTO>> GetItemsBySearch(string searchQuery);
    }
}
