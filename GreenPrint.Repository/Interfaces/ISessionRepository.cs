using GreenPrint.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Interfaces
{
    public interface ISessionRepository : IGenericRepository<Session>
    {

        /// <summary>
        /// Check a user session
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task CheckSession(int id);
    }
}
