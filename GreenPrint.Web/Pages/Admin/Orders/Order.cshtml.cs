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
        public ItemOrderDTO ItemOrderUpdate { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(int orderId)
        {
            if (!await HttpContext.AuthenticatedUserIsAdmin())
            {
                return RedirectToPage("/UnAuthorized");
            }

            Order = await _orderService.GetByIdAsync(orderId);

            if (Order == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostUpdateItemOrderAsync(int id, int itemid, int orderid, int wid, int quan, OrderStatusEnum status)
        {

            ItemOrderUpdate = new ItemOrderDTO
            {
                Id = id,
                ItemId = itemid,
                OrderId = orderid,
                WarehouseId = wid,
                Quantity = quan,
                Status = status
                
            };

            if (ModelState.IsValid)
            {
                await _itemOrderService.UpdateAsync(ItemOrderUpdate);
            }

            return RedirectToPage();
        }
    }
}
