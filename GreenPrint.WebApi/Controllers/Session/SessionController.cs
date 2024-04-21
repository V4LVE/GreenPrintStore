using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Session
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        #region
        private readonly ISessionService _SessionService;
        private readonly ILogger<SessionController> _logger;
        #endregion

        #region Constructor
        public SessionController(ISessionService SessionService, ILogger<SessionController> logger)
        {
            _SessionService = SessionService;
            _logger = logger;
        }
        #endregion


      
        [HttpGet("{SessionId:int}", Name = "GetSession")]
        public async Task<IActionResult> GetSession(int SessionId)
        {
            var temp = await _SessionService.GetByIdAsync(SessionId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(SessionDTO Session)
        {
            try
            {
                Session = await _SessionService.CreateAndReturn(Session);
                return CreatedAtAction("GetSession", new { SessionId = Session.Id }, Session);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete("{SessionId:int}")]
        [Route("remove")]
        public async Task<IActionResult> Remove(int SessionId)
        {
            var Session = await _SessionService.GetByIdAsync(SessionId);

            if (Session == null)
                return NotFound();

            try
            {
                await _SessionService.DeleteAsync(Session);
                return NoContent(); // Success
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(SessionDTO Session)
        {
            try
            {
                await _SessionService.UpdateAsync(Session);
                return CreatedAtAction("GetSession", new { SessionId = Session.Id }, Session);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch("{SessionId:int}")]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int SessionId, [FromBody] JsonPatchDocument<SessionDTO> patchDocument)
        {
            var Session = await _SessionService.GetByIdAsync(SessionId);
            if (Session == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(Session);
                await _SessionService.UpdateAsync(Session);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetSession", new { SessionId = Session.Id }, Session);
        }
    }
}
