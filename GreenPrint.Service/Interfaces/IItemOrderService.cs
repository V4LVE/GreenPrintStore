using GreenPrint.Repository.Entities;
using GreenPrint.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Interfaces
{
    public interface IItemOrderService : IGenericService<ItemOrderDTO>
    {
        /// <summary>
        /// Get all item orders by order id
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<List<ItemOrderDTO>> GetAllByOrderId(int orderId);
    }
}
