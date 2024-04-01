using GreenPrint.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Interfaces
{
    public interface IWarehouseItemService : IGenericService<WarehouseItemDTO>
    {
        /// <summary>
        /// Get all warehouse items by warehouse ID
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="warehouseID"></param>
        /// <returns></returns>
        Task<WarehouseItemDTO> GetByItemAndWarehouseId(int itemId, int warehouseId);
    }
}
