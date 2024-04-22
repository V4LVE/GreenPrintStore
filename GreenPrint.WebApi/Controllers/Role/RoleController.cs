using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.WebApi.ExtensionMethods;
using GreenPrint.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Role
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        #region
        private readonly IRoleService _RoleService;
        private readonly ILogger<RoleController> _logger;
        #endregion

        #region Constructor
        public RoleController(IRoleService RoleService, ILogger<RoleController> logger)
        {
            _RoleService = RoleService;
            _logger = logger;
        }
        #endregion





        [HttpGet("{roleId:int}", Name = "GetRole")]
        public async Task<IActionResult> GetRole(int roleId)
        {
            var temp = await _RoleService.GetByIdAsync(roleId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(RoleModel Role)
        {
            var RoleDto = Role.MapRoleToDto();

            try
            {
                RoleDto = await _RoleService.CreateAndReturn(RoleDto);
                return CreatedAtAction("GetRole", new { RoleId = RoleDto.Id }, RoleDto);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{roleId:int}")]
        public async Task<IActionResult> Remove(int roleId)
        {
            var Role = await _RoleService.GetByIdAsync(roleId);

            if (Role == null)
                return NotFound();

            try
            {
                await _RoleService.DeleteAsync(Role);
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
        public async Task<IActionResult> Edit(RoleDTO Role)
        {
            try
            {
                await _RoleService.UpdateAsync(Role);
                return CreatedAtAction("GetRole", new { RoleId = Role.Id }, Role);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update/{roleId:int}")]
        public async Task<IActionResult> EditPartially(int roleId, [FromBody] JsonPatchDocument<RoleDTO> patchDocument)
        {
            var Role = await _RoleService.GetByIdAsync(roleId);
            if (Role == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(Role);
                await _RoleService.UpdateAsync(Role);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetRole", new { RoleId = Role.Id }, Role);
        }
    }
}
