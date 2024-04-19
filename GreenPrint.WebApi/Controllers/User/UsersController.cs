using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.User
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        #region
        private readonly IUserService _UserService;
        private readonly ILogger<UsersController> _logger;
        #endregion

        #region Constructor
        public UsersController(IUserService UserService, ILogger<UsersController> logger)
        {
            _UserService = UserService;
            _logger = logger;
        }
        #endregion



        [HttpGet]
        [Route("GetDeffered")]
        public async IAsyncEnumerable<UserDTO> GetAsync()
        {
            foreach (var user in await _UserService.GetAllAsync())
            {
                yield return user;
            }
        }

        [HttpGet]
        public async Task<IEnumerable<UserDTO>> Get()
        {
            return await _UserService.GetAllAsync();
        }
    }
}
