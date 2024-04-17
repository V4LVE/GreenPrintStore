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
    public class WarehouseItemService(MappingService mappingService, IWarehouseItemRepository warehouseItemRepository) : GenericService<WarehouseItemDTO, IWarehouseItemRepository, WarehouseItem>(mappingService, warehouseItemRepository), IWarehouseItemService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly IWarehouseItemRepository _warehouseItemRepository = warehouseItemRepository;

        #endregion

        public async Task<WarehouseItemDTO> GetByItemAndWarehouseId(int warehouseId, int itemId)
        {
            var temp = _mappingService._mapper.Map<WarehouseItemDTO>(await _warehouseItemRepository.GetByItemAndWarehouseId(itemId, warehouseId));
            return temp;
        }

        public async Task<List<WarehouseItemDTO>> GetAllByByItemId(int itemId)
        {
            return _mappingService._mapper.Map<List<WarehouseItemDTO>>(await _warehouseItemRepository.GetAllByByItemId(itemId));
        }

        public async Task<bool> CheckWarehouseStock(int warehouseItemID, int amount)
        {
            bool tmpBool = await _warehouseItemRepository.CheckWarehouseStock(warehouseItemID, amount);
            return tmpBool;
        }

        public async Task<bool> RegisterProductAsync(WarehouseItemDTO warehouseItem)
        {
            try
            {
                await _warehouseItemRepository.RegisterProductAsync(_mappingService._mapper.Map<WarehouseItem>(warehouseItem));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
