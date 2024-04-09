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

        new public async Task<Item> GetByIdAsync(int id)
        {
            return await _dbContext.Items.AsNoTracking().Include(i => i.Category).FirstOrDefaultAsync(i => i.Id == id);
        }

        
        public async Task<List<Item>> GetItemsbyCategory(string category, PageOptions pageOptions)
        {
            return await _dbContext.Items.AsNoTracking().Where(i => i.Category.CategoryName == category).Include(c => c.Category).ToListAsync();
            

        }

        public async Task<List<Item>> GetItemsbyCategory(int categoryId, PageOptions pageOptions)
        {
            //return await _dbContext.Items.AsNoTracking().Where(i => i.CategoryId == categoryId).Include(c => c.Category).ToListAsync();
            var query = _dbContext.Items.AsNoTracking().Include(s => s.Category).Where(s => s.CategoryId == categoryId);

            return await query.Skip((pageOptions.CurrentPage -1) * pageOptions.PageSize).Take(pageOptions.PageSize).ToListAsync();
        }

        public async Task<List<Item>> GetItemsBySearch(string searchQuery)
        {
            return await _dbContext.Items.Where(i => i.ItemName.Contains(searchQuery) || i.Description.Contains(searchQuery)).ToListAsync();
        }

    }
}
