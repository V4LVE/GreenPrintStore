using GreenPrint.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Interfaces
{
    public interface IItemImageService : IGenericService<ItemImageDTO>
    {
        /// <summary>
        /// Get all images by item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<List<ItemImageDTO>> GetAllImagesByItemId(int itemId);
    }
}
