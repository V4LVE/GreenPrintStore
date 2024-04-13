using GreenPrint.Repository.Entities;
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

        /// <summary>
        /// Get all warehouse items by item ID
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<List<WarehouseItem>> GetAllByByItemId(int itemId);


        /// <summary>
        /// Checks if the <paramref name="amount"/> giving is available for the giving warehouse product(<paramref name="warehouseProductID"/>)
        /// </summary>
        /// <returns>"True" if available, "False" if not</returns>
        Task<bool> CheckWarehouseStock(int warehouseItemID, int amount);
    }
}
