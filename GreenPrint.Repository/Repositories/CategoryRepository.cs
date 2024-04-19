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
    public class CategoryRepository(StoreContext context) : GenericRepository<Category>(context), ICategoryRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion

        new public async Task<List<Category>> GetAllAsync()
        {
            List<Category> temp = await _dbContext.Categories.AsNoTracking().Include(w => w.Items).ToListAsync();

            return temp;
        }

        new public async Task<Category> GetByIdAsync(int id)
        {
            var temp = await _dbContext.Categories.AsNoTracking().Include(w => w.Items).SingleOrDefaultAsync(w => w.Id == id);

            return temp;
        }

    }
}
