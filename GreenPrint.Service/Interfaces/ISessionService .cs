using GreenPrint.Service.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.Interfaces
{
    public interface ISessionService : IGenericService<SessionDTO>
    {
        /// <summary>
        /// Creates a session
        /// </summary>
        /// <returns></returns>
        Task<SessionDTO> CreateSession(int userId);

        /// <summary>
        /// Check a user session
        /// </summary>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        Task<bool> CheckSession(int sessionId);
    }
}
