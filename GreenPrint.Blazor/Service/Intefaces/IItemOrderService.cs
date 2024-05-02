using GreenPrint.Blazor.Models;

namespace GreenPrint.Blazor.Service.Intefaces
{
    public interface IItemOrderService
    {
        /// <summary>
        /// Creates a new item order
        /// </summary>
        /// <param name="ItemOrders"></param>
        /// <returns></returns>
        public Task<HttpContent> CreateItemOrders(List<ItemOrder> ItemOrders);
    }
}
