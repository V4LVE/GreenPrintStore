using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using GreenPrint.Repository.Paging;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Interfaces
{
    public interface IItemRepository : IGenericRepository<Item>
    {
        /// <summary>
        /// Get all items with paging and sorting
        /// </summary>
        /// <param name="options"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<List<Item>> GetAllAsyncWithPagingAndSort(PageOptions options, OrderByOptionsItem order);

        /// <summary>
        /// Get all items by category
        /// </summary>
        /// <returns></returns>
        Task <List<Item>> GetItemsbyCategory(string category);
        Task<List<Item>> GetItemsbyCategory(int category);

        /// <summary>
        /// Get all items by search query
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task <List<Item>> GetItemsBySearch(string searchQuery);
    }
}
