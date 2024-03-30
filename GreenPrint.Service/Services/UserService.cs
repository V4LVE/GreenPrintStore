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
    public class UserService(StoreContext context, MappingService mappingService) : GenericService<UserDTO, IUserRepository, User>(mappingService, new UserRepository(context)), IUserService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly IUserRepository _UserRepository = new UserRepository(context);

        #endregion
    }
}
