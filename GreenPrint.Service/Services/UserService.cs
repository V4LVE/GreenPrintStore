using GreenPrint.Repository.Domain;
using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Interfaces;
using GreenPrint.Repository.Repositories;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Services.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Services
{
    public class UserService(MappingService mappingService, IUserRepository userRepository) : GenericService<UserDTO, IUserRepository, User>(mappingService, userRepository), IUserService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly IUserRepository _UserRepository = userRepository;

        #endregion

        public async Task<bool> IsUserAdminAsync(int id)
        {
            return await _UserRepository.IsUserAdminAsync(id);
        }

        public async Task<UserDTO> GetUserByEmailAsync(string email) => _mappingService._mapper.Map<UserDTO>(await _UserRepository.GetUserByEmailAsync(email));

        public async Task<bool> UserLoginAsync(string email, string password)
        {
            return await _UserRepository.UserLoginAsync(email, password);
        }
    }
}
