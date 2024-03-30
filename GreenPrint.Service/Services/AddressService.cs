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
    public class AddressService(StoreContext context, MappingService mappingService) : GenericService<AddressDTO, IAddressRepository, Address>(mappingService, new AddressRepository(context)), IAddressService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly IAddressRepository _addressRepository = new AddressRepository(context);

        #endregion
    }
}
