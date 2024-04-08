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

        public async Task CheckSession(int sessionId)
        {
            var session = await _dbContext.Sessions.SingleAsync(s => s.Id == sessionId && s.ExpirationDate < DateTime.Now);

            if (session != null)
            {
                _dbContext.Sessions.Remove(session);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
