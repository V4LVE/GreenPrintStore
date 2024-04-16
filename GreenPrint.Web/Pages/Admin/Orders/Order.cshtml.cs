using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Admin.Orders
{
    public class OrderModel : PageModel
    {
        #region Services    
        private readonly IOrderService _orderService;
        private readonly IItemOrderService _itemOrderService;
        #endregion

        #region Constructor
        public OrderModel(IOrderService orderService, IItemOrderService itemOrderService)
        {
            _orderService = orderService;
            _itemOrderService = itemOrderService;
        }
        #endregion

        #region Properties
        [BindProperty]
        public OrderDTO Order { get; set; }
        [BindProperty]
        public List<ItemOrderDTO> ItemOrders { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(int orderId)
        {
            if (!await HttpContext.AuthenticatedUserIsAdmin())
            {
                return RedirectToPage("/UnAuthorized");
            }

            Order = await _orderService.GetByIdAsync(orderId);
            ItemOrders = Order.ItemOrders;

            if (Order == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            await _itemOrderService.UpdateListAsync(ItemOrders);
            Order = await _orderService.GetByIdAsync(Order.Id);
            await _orderService.CheckOrderStatus(Order.ItemOrders, Order);

            return RedirectToPage();
        }
    }
}
