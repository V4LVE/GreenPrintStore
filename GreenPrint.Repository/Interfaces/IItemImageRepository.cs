using GreenPrint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Interfaces
{
    public interface IItemImageRepository : IGenericRepository<ItemImage>
    {
        /// <summary>
        /// Get all images by item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<List<ItemImage>> GetAllImagesByItemId(int itemId);
    }
}
