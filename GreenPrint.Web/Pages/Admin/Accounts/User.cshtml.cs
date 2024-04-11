using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GreenPrint.Web.Pages.Admin.Accounts
{
    public class UserModel : PageModel
    {
        #region backing Fields
        private readonly IUserService _UserService;
        private readonly IRoleService _RoleService;
        #endregion

        #region Constructor
        public UserModel(IUserService UserService, IRoleService roleService)
        {
            _UserService = UserService;
            _RoleService = roleService;
        }
        #endregion

        #region Properties
        [BindProperty]
        public UserDTO User { get; set; }
        [BindProperty]
        public List<RoleDTO> Roles { get; set; }
        [BindProperty]
        public SelectList SelectRoles { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(int UserId)
        {
            if (!await HttpContext.AuthenticatedUserIsAdmin())
            {
                return RedirectToPage("/UnAuthorized");
            }

            User = await _UserService.GetByIdAsync(UserId);
            Roles = await _RoleService.GetAllAsync();
            SelectRoles = new SelectList(Roles, nameof(RoleDTO.Id), nameof(RoleDTO.RoleName));

            if (User != null)
            {
                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            await OnGet(User.Id);
            
            if (ModelState.IsValid)
            {
                await _UserService.UpdateAsync(User);
                return RedirectToPage("/Admin/Accounts/Users");
            }

            
            return Page();
        }
    }
}
