using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Admin.Accounts
{
    public class UsersModel : PageModel
    {
        #region backing Fields
        private readonly IUserService _UserService;
        #endregion

        #region Constructor
        public UsersModel(IUserService UserService)
        {
            _UserService = UserService;
        }
        #endregion

        #region Properties
        public List<UserDTO> Users { get; set; }
        #endregion

        public async Task<IActionResult> OnGet()
        {
            Users = await _UserService.GetAllAsync();

            return Page();
        }
    }
}
