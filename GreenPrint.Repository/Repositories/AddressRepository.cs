using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Repositories
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext;
        #endregion

        #region Constructor
        public AddressRepository(StoreContext context) : base(context)
        {
            _dbContext = context;
        }
        #endregion
    }
}
