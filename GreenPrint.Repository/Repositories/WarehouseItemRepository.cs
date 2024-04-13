using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Repositories
{
    public class WarehouseItemRepository(StoreContext context) : GenericRepository<WarehouseItem>(context), IWarehouseItemRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion

        public async Task<WarehouseItem> GetByItemAndWarehouseId(int warehouseId, int itemId)
        {
            var temp = await _dbContext.WarehouseItems.AsNoTracking().FirstOrDefaultAsync(wi => wi.WarehouseId == warehouseId && wi.ItemId == itemId);
            return temp;
        }

        public async Task<List<WarehouseItem>> GetAllByByItemId(int itemId)
        {
            var temp = await _dbContext.WarehouseItems.AsNoTracking()
                .Include(wi => wi.Item)
                .Include(wi => wi.Warehouse)
                .Where(wi => wi.ItemId == itemId && wi.Quantity > 0)
                .ToListAsync();
            return temp;
        }

        public async Task<bool> CheckWarehouseStock(int warehouseItemID, int amount)
        {
            WarehouseItem warehouseItem = await _dbContext.WarehouseItems.SingleAsync(wp => wp.ItemId == warehouseItemID);
            if (warehouseItem.Quantity >= amount)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
