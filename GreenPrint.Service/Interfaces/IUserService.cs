using GreenPrint.Repository.Entities;
using GreenPrint.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Interfaces
{
    public interface IUserService : IGenericService<UserDTO>
    {
        /// <summary>
        /// Check if the user is an admin
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<bool> IsUserAdminAsync(int userId);

        /// <summary>
        /// Check if the user login is valid
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<bool> UserLoginAsync(string email, string password);

        /// <summary>
        /// Get the user by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Task<UserDTO> GetUserByEmailAsync(string email);
    }
}
