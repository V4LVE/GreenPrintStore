using GreenPrint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Interfaces
{
    public interface IWarehouseItemRepository : IGenericRepository<WarehouseItem>
    {
        /// <summary>
        /// Get all warehouse items by warehouse id
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="warehouseId"></param>
        /// <returns></returns>
        Task<WarehouseItem> GetByItemAndWarehouseId(int itemId, int warehouseId);

        /// <summary>
        /// Get all warehouse items by item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<List<WarehouseItem>> GetAllByByItemId(int itemId);
    }
}
