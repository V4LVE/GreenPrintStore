using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Admin.Accounts
{
    public class RolesModel : PageModel
    {
        #region backing Fields
        private readonly IRoleService _RoleService;
        #endregion

        #region Constructor
        public RolesModel(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }
        #endregion

        #region Properties
        public List<RoleDTO> Roles { get; set; }
        #endregion

        public async Task<IActionResult> OnGet()
        {
            Roles = await _RoleService.GetAllAsync();

            return Page();
        }
    }
}
