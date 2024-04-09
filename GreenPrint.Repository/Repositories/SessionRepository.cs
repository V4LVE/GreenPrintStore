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
    public class SessionRepository(StoreContext context) : GenericRepository<Session>(context), ISessionRepository
    {
        #region Backing fields
        private readonly StoreContext _dbContext = context;

        #endregion
        #region Constructor
        #endregion

        public async Task<bool> CheckSession(int sessionId)
        {
            var session = await _dbContext.Sessions.AsNoTracking().SingleAsync(s => s.Id == sessionId);

            if (session.ExpirationDate < DateTime.Now)
            {
                _dbContext.Sessions.Remove(session);
                await _dbContext.SaveChangesAsync();
                return false;
            }

            return true;
        }
    }
}
