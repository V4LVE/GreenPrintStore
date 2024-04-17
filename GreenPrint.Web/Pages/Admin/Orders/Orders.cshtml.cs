using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Admin.Orders
{
    public class OrdersModel : PageModel
    {
        #region Services
        private readonly IOrderService _orderService;
        #endregion

        #region Constructor
        public OrdersModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion

        #region Properties
        public List<OrderDTO> Orders { get; set; }
        #endregion

        public async Task<IActionResult> OnGet()
        {
            if (!await HttpContext.AuthenticatedUserIsAdmin())
            {
                return RedirectToPage("/UnAuthorized");
            }
            
            Orders = await _orderService.GetAllAsync();

            return Page();
        }
    }
}
