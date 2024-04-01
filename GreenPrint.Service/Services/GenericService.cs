using GreenPrint.Repository.Interfaces;
using GreenPrint.Repository.Paging;
using GreenPrint.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Services.Services
{
    public abstract class GenericService<DTO, IRepository, Entity> : IGenericService<DTO> where DTO : class where IRepository : IGenericRepository<Entity> where Entity : class
    {
        #region backing fields
        private readonly IRepository _genericRepository;
        private readonly MappingService _mappingService;
        #endregion

        #region Constructor
        protected GenericService(MappingService mappingService, IRepository genericRepository)
        {
            _mappingService = mappingService;
            _genericRepository = genericRepository;
        }
        #endregion

        public async Task CreateAsync(DTO entity)
        {
            await _genericRepository.CreateAsync(_mappingService._mapper.Map<Entity>(entity));
        }

        public async Task<DTO> CreateAndReturn(DTO entity)
        {
            return _mappingService._mapper.Map<DTO>(await _genericRepository.CreateAndReturn(_mappingService._mapper.Map<Entity>(entity)));
        }

        public async Task DeleteAsync(DTO entity)
        {
            await _genericRepository.DeleteAsync(_mappingService._mapper.Map<Entity>(entity));
        }

        public async Task<List<DTO>> GetAllAsync()
        {
            return _mappingService._mapper.Map<List<DTO>>(await _genericRepository.GetAllAsync());
        }


        public async Task<List<DTO>> GetAllAsyncWithPaging(PageOptions options)
        {
            return _mappingService._mapper.Map<List<DTO>>(await _genericRepository.GetAllAsyncWithPaging(options));
        }

        public async Task<DTO> GetByIdAsync(int id)
        {
            return _mappingService._mapper.Map<DTO>(await _genericRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(DTO entity)
        {
            await _genericRepository.UpdateAsync(_mappingService._mapper.Map<Entity>(entity));
        }
    }
}
