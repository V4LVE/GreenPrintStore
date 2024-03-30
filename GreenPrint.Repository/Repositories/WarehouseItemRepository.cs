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
    public class WarehouseItemRepository(StoreContext context) : GenericRepository<WarehouseItem>(context), IWarehouseItemRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion

    }
}
