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
    public class ItemOrderRepository(StoreContext context) : GenericRepository<ItemOrder>(context), IItemOrderRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion
        #region Constructor
        #endregion

        public async Task<List<ItemOrder>> GetAllByOrderId(int orderId) => await _dbContext.ItemOrders
            .AsNoTracking()
            .Include(io => io.Item)
            .ThenInclude(io => io.ItemImages)
            .Include(io => io.Warehouse)
            .Where(io => io.OrderId == orderId)
            .ToListAsync();

    }
}
