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
    public class SessionService(MappingService mappingService, ISessionRepository SessionRepository) : GenericService<SessionDTO, ISessionRepository, Session>(mappingService, SessionRepository), ISessionService
    {
        #region backing fields
        private readonly MappingService _mappingService = mappingService;
        private readonly ISessionRepository _SessionRepository = SessionRepository;

        #endregion

        public async Task<SessionDTO> CreateSession(int userId)
        {
            SessionDTO session = new()
            {
                UserId = userId,
                SessionToken = Guid.NewGuid(),
                ExpirationDate = DateTime.Now.AddHours(1)
            };

            return _mappingService._mapper.Map<SessionDTO>(await _SessionRepository.CreateAndReturn(_mappingService._mapper.Map<Session>(session)));
        }

        public async Task<bool> CheckSession(int sessionId)
        {
            return await _SessionRepository.CheckSession(sessionId);
        }
    }
}
