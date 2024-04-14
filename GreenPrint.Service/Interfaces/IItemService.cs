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
        /// Get all items by category
        /// </summary>
        /// <returns></returns>
        Task<List<ItemDTO>> GetItemsByCategory(string category, PageOptions pageOptions);
        Task<List<ItemDTO>> GetItemsByCategory(int category, PageOptions pageOptions);
        Task<List<ItemDTO>> GetItemsByCategory(int category, PageOptions pageOptions, OrderByOptionsItem orderBy);

        /// <summary>
        /// Get all items by search query
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<List<ItemDTO>> GetItemsBySearch(string searchQuery, PageOptions pageOptions, OrderByOptionsItem orderBy);
    }
}
