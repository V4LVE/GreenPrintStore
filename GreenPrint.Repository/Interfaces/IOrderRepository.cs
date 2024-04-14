using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        /// <summary>
        /// Get all orders by search query
        /// </summary>
        /// <param name="searchQuery"></param>
        /// <returns></returns>
        Task<List<Order>> GetOrdersBySearch(string searchQuery);

        /// <summary>
        /// Get all orders by status
        /// </summary>
        /// <param name="statusEnum"></param>
        /// <returns></returns>
        Task<List<Order>> GetOrdersByStatus(OrderStatusEnum status);

        /// <summary>
        /// Get all orders by customer ID
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Task <List<Order>> GetAllByCustomerId(int customerId);
    }
}
