using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using GreenPrint.Repository.Interfaces;
using GreenPrint.Repository.Repositories;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Services
{
    public class OrderService(MappingService mappingService, IOrderRepository orderRepository) : GenericService<OrderDTO, IOrderRepository, Order>(mappingService, orderRepository), IOrderService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly IOrderRepository _OrderRepository = orderRepository;

        #endregion

        public async Task<List<Order>> GetOrdersBySearch(string searchQuery)
        {
            return await _OrderRepository.GetOrdersBySearch(searchQuery);
        }

        public async Task<List<Order>> GetOrdersByStatus(OrderStatusEnum status)
        {
            return await _OrderRepository.GetOrdersByStatus(status);
        }

        public async Task CheckOrderStatus(List<ItemOrderDTO> ProductOrders, OrderDTO Order)
        {
            List<ItemOrderDTO> tmpInProgress = ProductOrders.FindAll(x => x.Status == OrderStatusEnum.Processing);
            List<ItemOrderDTO> tmpCompleted = ProductOrders.FindAll(x => x.Status == OrderStatusEnum.Delivered);
            List<ItemOrderDTO> tmpCreated = ProductOrders.FindAll(x => x.Status == OrderStatusEnum.Created);
            List<ItemOrderDTO> tmpAwaitDelivery = ProductOrders.FindAll(x => x.Status == OrderStatusEnum.Shipped);
            List<ItemOrderDTO> tmpCancelled = ProductOrders.FindAll(x => x.Status == OrderStatusEnum.Cancelled);
            List<ItemOrderDTO> tmpRefunded = ProductOrders.FindAll(x => x.Status == OrderStatusEnum.Pending);
            Order.Customer = null;

            if (tmpInProgress.Count > 0)
            {
                Order.Status = OrderStatusEnum.Processing;
                await UpdateAsync(Order);
            }
            if (tmpCompleted.Count == ProductOrders.Count)
            {
                Order.Status = OrderStatusEnum.Delivered;
                await UpdateAsync(Order);
            }
            if (tmpAwaitDelivery.Count == ProductOrders.Count)
            {
                Order.Status = OrderStatusEnum.Shipped;
                await UpdateAsync(Order);
            }
            if (tmpCreated.Count == ProductOrders.Count)
            {
                Order.Status = OrderStatusEnum.Created;
                await UpdateAsync(Order);
            }
            if (tmpCancelled.Count == ProductOrders.Count)
            {
                Order.Status = OrderStatusEnum.Cancelled;
                await UpdateAsync(Order);
            }
            if (tmpRefunded.Count == ProductOrders.Count)
            {
                Order.Status = OrderStatusEnum.Pending;
                await UpdateAsync(Order);
            }
        }

        public async Task<List<OrderDTO>> GetAllByCustomerId(int customerId)
        {
            return _mappingService._mapper.Map<List<OrderDTO>>(await _OrderRepository.GetAllByCustomerId(customerId));
        }
    }
}
