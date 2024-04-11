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
    public class RoleRepository(StoreContext context) : GenericRepository<Role>(context), IRoleRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion

        new public async Task<List<Role>> GetAllAsync()
        {
            List<Role> temp = await _dbContext.Roles.AsNoTracking().Include(r => r.Users).ToListAsync();

            return temp;
        }

        new public async Task<Role> GetByIdAsync(int id)
        {
            Role entity = await _dbContext.Roles.AsNoTracking().Include(r => r.Users).SingleOrDefaultAsync(r => r.Id == id);
            return entity;
        }

    }
}
