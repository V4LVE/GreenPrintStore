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
    public class ItemImageService(MappingService mappingService, IItemImageRepository ItemImageRepository) : GenericService<ItemImageDTO, IItemImageRepository, ItemImage>(mappingService, ItemImageRepository), IItemImageService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly IItemImageRepository _ItemImageRepository = ItemImageRepository;

        #endregion

        public async Task<List<ItemImageDTO>> GetAllImagesByItemId(int itemId)
        {
            var temp = _mappingService._mapper.Map<List<ItemImageDTO>>(await _ItemImageRepository.GetAllImagesByItemId(itemId));

            return temp;
        }
    }
}
