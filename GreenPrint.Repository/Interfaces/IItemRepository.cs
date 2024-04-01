using GreenPrint.Repository.Entities;
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
