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

        public async Task<List<ItemDTO>> GetItemsBySearch(string searchQuery, PageOptions pageOptions, OrderByOptionsItem orderBy)
        {
            return _mappingService._mapper.Map<List<ItemDTO>>(await _ItemRepository.GetItemsBySearch(searchQuery,pageOptions,orderBy));
        }

        public async Task<List<ItemDTO>> GetItemsByCategory(int category)
        {
            return _mappingService._mapper.Map<List<ItemDTO>>(await _ItemRepository.GetItemsbyCategory(category));
        }


        public async Task<List<ItemDTO>> GetItemsByCategory(string category, PageOptions pageOptions)
        {
            return _mappingService._mapper.Map<List<ItemDTO>>(await _ItemRepository.GetItemsbyCategory(category, pageOptions));
        }

        public async Task<List<ItemDTO>> GetItemsByCategory(int categoryId, PageOptions pageOptions)
        {
            return _mappingService._mapper.Map<List<ItemDTO>>(await _ItemRepository.GetItemsbyCategory(categoryId, pageOptions));
        }
        public async Task<List<ItemDTO>> GetItemsByCategory(int categoryId, PageOptions pageOptions, OrderByOptionsItem orderBy)
        {
            return _mappingService._mapper.Map<List<ItemDTO>>(await _ItemRepository.GetItemsbyCategory(categoryId, pageOptions,orderBy));
        }

    }
}
