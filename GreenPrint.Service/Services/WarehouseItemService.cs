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
    public class WarehouseItemService(StoreContext context, MappingService mappingService) : GenericService<WarehouseItemDTO, IWarehouseItemRepository, WarehouseItem>(mappingService, new WarehouseItemRepository(context)), IWarehouseItemService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly IWarehouseItemRepository _warehouseItemRepository = new WarehouseItemRepository(context);

        #endregion

        public async Task<WarehouseItemDTO> GetByItemAndWarehouseId(int warehouseId, int itemId)
        {
            var temp = _mappingService._mapper.Map<WarehouseItemDTO>(await _warehouseItemRepository.GetByItemAndWarehouseId(warehouseId, itemId));
            return temp;
        }
    }
}
