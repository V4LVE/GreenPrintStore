using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using GreenPrint.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Interfaces
{
    public interface IOrderService : IGenericService<OrderDTO>
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
    }
}
