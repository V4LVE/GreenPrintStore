using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Interfaces;
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

        public async Task<List<Item>> GetItemsbyCategory(string category)
        {
            return await _dbContext.Items.AsNoTracking().Where(i => i.Category.CategoryName == category).ToListAsync();
        }

        public async Task<List<Item>> GetItemsbyCategory(int categoryId)
        {
            return await _dbContext.Items.AsNoTracking().Where(i => i.CategoryId == categoryId).ToListAsync();
        }

        public async Task<List<Item>> GetItemsBySearch(string searchQuery)
        {
            var stringProps = typeof(Item).GetProperties().Where(p => p.PropertyType == typeof(string));

            return await _dbContext.Items.AsNoTracking().Where(item => stringProps.Any(prop => prop.GetValue(item) == searchQuery)).ToListAsync();
        }

    }
}
