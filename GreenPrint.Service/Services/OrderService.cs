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
    }
}
