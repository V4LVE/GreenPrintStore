using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Interfaces;
using GreenPrint.Repository.Repositories;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Services
{
    public class CustomerService(StoreContext context, MappingService mappingService) : GenericService<CustomerDTO, ICustomerRepository, Customer>(mappingService, new CustomerRepository(context)), ICustomerService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly ICustomerRepository _CustomerRepository = new CustomerRepository(context);

        #endregion
    }
}
