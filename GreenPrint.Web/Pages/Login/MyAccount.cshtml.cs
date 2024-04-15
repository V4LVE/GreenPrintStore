using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Web.Extensions;
using GreenPrint.Web.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Login
{
    public class MyAccountModel : PageModel
    {
        #region Services
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
		#endregion

		#region constructor
		public MyAccountModel(IUserService userService, ICustomerService customerService)
        {
			_userService = userService;
			_customerService = customerService;
		}
        #endregion

        #region Properties
        [BindProperty]
        public UserDTO User { get; set; }
        [BindProperty]
        public CustomerDTO Customer { get; set; }
        [BindProperty]
        public AddressDTO Address { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(int userId)
        {
            if (userId != await HttpContext.GetUser())
            {
                return RedirectToPage("/UnAuthorized");
            }

            User = await _userService.GetByIdAsync(userId);


            return Page();
        }
    }
}
