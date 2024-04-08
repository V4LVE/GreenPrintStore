using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using GreenPrint.Repository.Interfaces;
using GreenPrint.Repository.Paging;
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
    public class ItemService(MappingService mappingService, IItemRepository itemRepository) : GenericService<ItemDTO, IItemRepository, Item>(mappingService, itemRepository), IItemService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly IItemRepository _ItemRepository = itemRepository;

        #endregion

        public async Task<List<ItemDTO>> GetItemsBySearch(string searchQuery)
        {
            return _mappingService._mapper.Map<List<ItemDTO>>(await _ItemRepository.GetItemsBySearch(searchQuery));
        }

        public async Task<List<ItemDTO>> GetItemsbyCategory(string category)
        {
            return _mappingService._mapper.Map<List<ItemDTO>>(await _ItemRepository.GetItemsbyCategory(category));
        }

        public async Task<List<ItemDTO>> GetItemsbyCategory(int categoryId)
        {
            return _mappingService._mapper.Map<List<ItemDTO>>(await _ItemRepository.GetItemsbyCategory(categoryId));
        }

        public async Task<List<ItemDTO>> GetAllAsyncWithPaging(PageOptions options, OrderByOptionsItem order)
        {
            return _mappingService._mapper.Map<List<ItemDTO>>(await _ItemRepository.GetAllAsyncWithPagingAndSort(options, order));
        }
    }
}
