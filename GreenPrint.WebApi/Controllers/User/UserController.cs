using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.User
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        #region
        private readonly IUserService _UserService;
        private readonly ILogger<UserController> _logger;
        #endregion

        #region Constructor
        public UserController(IUserService UserService, ILogger<UserController> logger)
        {
            _UserService = UserService;
            _logger = logger;
        }
        #endregion





        [HttpGet("{UserId:int}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(int UserId)
        {
            var temp = await _UserService.GetByIdAsync(UserId);

            if (temp != null)
            {
                //temp.Customer.User = null;
                
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(UserDTO User)
        {
            try
            {
                User.Customer = new CustomerDTO();
                User = await _UserService.CreateAndReturn(User);
                return CreatedAtAction("GetUser", new { UserId = User.Id }, User);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{UserId:int}")]
        public async Task<IActionResult> Remove(int UserId)
        {
            var User = await _UserService.GetByIdAsync(UserId);

            if (User == null)
                return NotFound();

            try
            {
                await _UserService.DeleteAsync(User);
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
        public async Task<IActionResult> Edit(UserDTO User)
        {
            try
            {
                await _UserService.UpdateAsync(User);
                return CreatedAtAction("GetUser", new { UserId = User.Id }, User);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update/{UserId:int}")]
        public async Task<IActionResult> EditPartially(int UserId, [FromBody] JsonPatchDocument<UserDTO> patchDocument)
        {
            var User = await _UserService.GetByIdAsync(UserId);
            if (User == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(User);
                await _UserService.UpdateAsync(User);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetUser", new { UserId = User.Id }, User);
        }
    }
}
