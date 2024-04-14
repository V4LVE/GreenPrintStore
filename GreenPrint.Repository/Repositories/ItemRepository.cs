using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using GreenPrint.Repository.Filtering.Orders;
using GreenPrint.Repository.Interfaces;
using GreenPrint.Repository.Paging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Repositories
{
    public class ItemRepository(StoreContext context) : GenericRepository<Item>(context), IItemRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion

        new public async Task<List<Item>> GetAllAsync()
        {
            return await _dbContext.Items.AsNoTracking()
                .Include(i => i.ItemImages)
                .ToListAsync();
        }

        new public async Task<Item> GetByIdAsync(int id)
        {
            return await _dbContext.Items.AsNoTracking()
                .Include(i => i.Category)
                .Include(i => i.ItemImages)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        
        public async Task<List<Item>> GetItemsbyCategory(string category, PageOptions pageOptions)
        {
            return await _dbContext.Items.AsNoTracking()
                .Include(c => c.Category)
                .Where(i => i.Category.CategoryName == category)
                .Include(s => s.ItemImages)
                .ToListAsync();
        }

        public async Task<List<Item>> GetItemsbyCategory(int categoryId, PageOptions pageOptions)
        {
            //return await _dbContext.Items.AsNoTracking().Where(i => i.CategoryId == categoryId).Include(c => c.Category).ToListAsync();
            var query = _dbContext.Items.AsNoTracking()
                .Include(s => s.Category)
                .Include(s => s.ItemImages)
                .Where(s => s.CategoryId == categoryId);

            return await query.Skip((pageOptions.CurrentPage -1) * pageOptions.PageSize).Take(pageOptions.PageSize).ToListAsync();
        }

        public async Task<List<Item>> GetItemsbyCategory(int categoryId, PageOptions pageOptions, OrderByOptionsItem orderBy)
        {
            //return await _dbContext.Items.AsNoTracking().Where(i => i.CategoryId == categoryId).Include(c => c.Category).ToListAsync();
            var query = _dbContext.Items.AsNoTracking()
                .Include(s => s.Category)
                .Include(s => s.ItemImages)
                .Where(s => s.CategoryId == categoryId)
                .OrderItemsBy(orderBy);

            return await query.Skip((pageOptions.CurrentPage - 1) * pageOptions.PageSize).Take(pageOptions.PageSize).ToListAsync();
        }

        public async Task<List<Item>> GetItemsBySearch(string searchQuery, PageOptions pageOptions, OrderByOptionsItem orderBy)
        {
            var query = _dbContext.Items.AsNoTracking()
                .Include(s => s.Category)
                .Include(s => s.ItemImages)
                .Where(s => s.ItemName.Contains(searchQuery) || s.Description.Contains(searchQuery))
                .OrderItemsBy(orderBy);

            return await query.Skip((pageOptions.CurrentPage - 1) * pageOptions.PageSize).Take(pageOptions.PageSize).ToListAsync();
        }

    }
}
