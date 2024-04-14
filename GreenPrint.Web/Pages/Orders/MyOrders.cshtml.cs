using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Orders
{
    public class MyOrdersModel : PageModel
    {
        #region Services
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;
        #endregion

        #region constructor
        public MyOrdersModel(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }
        #endregion

        #region Properties
        public List<OrderDTO> Orders { get; set; }
        public UserDTO User { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(int userId)    
        {
            if (userId == null)
            {
                return NotFound();
            }
            if (userId != await HttpContext.GetUser())
            {
                return RedirectToPage("/UnAuthorized");
            }

            User = await _userService.GetByIdAsync(userId);
            Orders = await _orderService.GetAllByCustomerId((int)User.CustomerId);

            return Page();
        }
    }
}
