using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using GreenPrint.Repository.Filtering.Orders;
using GreenPrint.Repository.Interfaces;
using GreenPrint.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Repositories
{
    public class OrderRepository(StoreContext context) : GenericRepository<Order>(context), IOrderRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion

        public async Task<List<Order>> GetAllAsyncWithPaging(PageOptions options, OrderByOptionsOrder order)
        {
            var query = _dbContext.Orders.AsNoTracking().OrderOrdersBy(order);

            options.SetupRestOfDto(query);
            return await query.Page(options.PageNum - 1, options.PageSize).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersBySearch(string searchQuery)
        {
            return await _dbContext.Orders.AsNoTracking().Where(
                x => x.Customer.FirstName.Equals(searchQuery) ||
                x.Customer.Email.Contains(searchQuery)).ToListAsync();
        }

        public async Task<List<Order>> GetOrdersByStatus(OrderStatusEnum status)
        {
            return await _dbContext.Orders.AsNoTracking().Where(x => x.Status == status).ToListAsync();
        }

    }
}
