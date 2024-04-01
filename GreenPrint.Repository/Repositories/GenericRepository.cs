using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Interfaces;
using GreenPrint.Repository.Paging;

namespace GreenPrint.Repository.Repositories
{
    public abstract class GenericRepository<E> : IGenericRepository<E> where E : class
    {
        #region Backing fields
        private readonly StoreContext _dbContext;
        #endregion

        #region Constructor
        protected GenericRepository(StoreContext context)
        {
            _dbContext = context;
        }
        #endregion

        public async Task CreateAsync(E entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<E> CreateAndReturn(E entity)
        {
            _dbContext.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(E entity)
        {
            _dbContext.Set<E>().Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<E>> GetAllAsync()
        {
            List<E> temp = new(await _dbContext.Set<E>().AsNoTracking().ToListAsync());

            return temp;
        }

        public async Task<List<E>> GetAllAsyncWithPaging(SortFilterPageOptions options)
        {
            var query = _dbContext.Set<E>().AsNoTracking();

            options.SetupRestOfDto(query);
            return await query.Page(options.PageNum - 1, options.PageSize).ToListAsync();
        }

        public async Task<E> GetByIdAsync(int id)
        {
            return await _dbContext.Set<E>().FindAsync(id);
        }

        public async Task DeleteAsync(E entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
