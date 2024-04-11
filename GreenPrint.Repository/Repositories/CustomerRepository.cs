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
    public class CustomerRepository(StoreContext context) : GenericRepository<Customer>(context), ICustomerRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion

        new public async Task<Customer> GetByIdAsync(int id)
        {
            Customer entity = await _dbContext.Customers.AsNoTracking().Include(c => c.Address).SingleOrDefaultAsync(c => c.Id == id);
            return entity;
        }

    }
}
