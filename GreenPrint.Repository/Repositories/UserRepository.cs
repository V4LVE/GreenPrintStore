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
    public class UserRepository(StoreContext context) : GenericRepository<User>(context), IUserRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion

        public async Task<bool> IsUserAdminAsync(int id)
        {
            return await _dbContext.Users.AsNoTracking().AnyAsync(u => u.Id == id && u.Roleid == 3);
        }

        public async Task<User> GetUserByEmailAsync(string email) => await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

        public async Task<bool> UserLoginAsync(string email, string password)
        {
            return await _dbContext.Users.AsNoTracking().AnyAsync(u => u.Email == email && u.Password == password);
        }

        

    }
}
