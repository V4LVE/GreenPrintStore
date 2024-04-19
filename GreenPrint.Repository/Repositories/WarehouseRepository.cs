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
    public class WarehouseRepository(StoreContext context) : GenericRepository<Warehouse>(context), IWarehouseRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion

        new public async Task<List<Warehouse>> GetAllAsync()
        {
            List<Warehouse> temp = await _dbContext.Warehouses.AsNoTracking().Include(w => w.Address).ToListAsync();

            return temp;
        }

        new public async Task<Warehouse> GetByIdAsync(int id)
        {
            var temp = await _dbContext.Warehouses.AsNoTracking().Include(w => w.Address).SingleOrDefaultAsync(w => w.Id == id);

            return temp;
        }

    }
}
