using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Admin.Accounts
{
    public class RoleModel : PageModel
    {
        #region backing Fields
        private readonly IRoleService _roleService;
        #endregion

        #region Constructor
        public RoleModel(IRoleService roleService)
        {
            _roleService = roleService;
        }
        #endregion

        #region Properties
        [BindProperty]
        public RoleDTO Role { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(int roleId)
        {
            if (!await HttpContext.AuthenticatedUserIsAdmin())
            {
                return RedirectToPage("/UnAuthorized");
            }

            Role = await _roleService.GetByIdAsync(roleId);

            if (Role != null)
            {
                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (ModelState.IsValid)
            {
                await _roleService.UpdateAsync(Role);
                return RedirectToPage("/Admin/Accounts/Roles");
            }

            await OnGet(Role.Id);
            return Page();
        }
    }
}
