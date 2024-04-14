using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
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
    public class ItemOrderService(MappingService mappingService, IItemOrderRepository itemOrderRepository) : GenericService<ItemOrderDTO, IItemOrderRepository, ItemOrder>(mappingService, itemOrderRepository), IItemOrderService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly IItemOrderRepository _ItemOrderRepository = itemOrderRepository;

        #endregion

        public async Task<List<ItemOrderDTO>> GetAllByOrderId(int orderId)
        {
            var temp = _mappingService._mapper.Map<List<ItemOrderDTO>>(await _ItemOrderRepository.GetAllByOrderId(orderId));
            return temp;
        }
    }
}
