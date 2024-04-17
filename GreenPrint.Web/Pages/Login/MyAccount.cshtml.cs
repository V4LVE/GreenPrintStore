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
        private readonly IOrderService _orderService;
		#endregion

		#region constructor
		public MyAccountModel(IUserService userService, ICustomerService customerService, IOrderService orderService)
        {
			_userService = userService;
			_customerService = customerService;
            _orderService = orderService;
		}
        #endregion

        #region Properties
        [BindProperty]
        public UserDTO User { get; set; }
        [BindProperty]
        public List<OrderDTO> Orders { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(int userId)
        {
            if (userId != await HttpContext.GetUser())
            {
                return RedirectToPage("/UnAuthorized");
            }

            User = await _userService.GetByIdAsync(userId);
            Orders = await _orderService.GetAllByCustomerId(userId);


            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            await _userService.UpdateAsync(User);

            return RedirectToPage();
        }
    }
}
