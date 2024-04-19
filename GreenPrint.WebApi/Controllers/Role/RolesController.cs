using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Role
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        #region
        private readonly IRoleService _RoleService;
        private readonly ILogger<RolesController> _logger;
        #endregion

        #region Constructor
        public RolesController(IRoleService RoleService, ILogger<RolesController> logger)
        {
            _RoleService = RoleService;
            _logger = logger;
        }
        #endregion





        [HttpGet]
        public async Task<IEnumerable<RoleDTO>> Get()
        {
            return await _RoleService.GetAllAsync();
        }
    }
}
