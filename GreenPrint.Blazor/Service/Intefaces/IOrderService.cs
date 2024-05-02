using GreenPrint.Blazor.Models;

namespace GreenPrint.Blazor.Service.Intefaces
{
    public interface IOrderService
    {
        /// <summary>
        /// Creates a new order
        /// </summary>
        /// <param name="Order"></param>
        /// <returns></returns>
        public Task<Order> CreateOrder(Order Order);

        /// <summary>
        /// Get an order by id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Task<Order> GetOrderByIdAsync(int orderId);
    }
}
