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

        /// <summary>
        /// Checks the status of the giving order(<paramref name="Order"/>) and its related ProductOrders(<paramref name="ItemOrders"/>)
        /// </summary>
        /// <param name="ItemOrders"></param>
        /// <param name="Order"></param>
        Task CheckOrderStatus(List<ItemOrderDTO> ItemOrders, OrderDTO Order);
    }
}
