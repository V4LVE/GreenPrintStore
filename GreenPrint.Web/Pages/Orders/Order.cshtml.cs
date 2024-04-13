using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Orders
{
    public class OrderModel : PageModel
    {
        #region Services
        private readonly IOrderService _orderService;
        private readonly IItemOrderService _itemOrderService;
        private readonly ICustomerService _customerService;
        #endregion

        #region constructor
        public OrderModel(IItemOrderService itemOrderService, IOrderService orderService, ICustomerService customerService)
        {
            _itemOrderService = itemOrderService;
            _orderService = orderService;
            _customerService = customerService;
        }
        #endregion

        #region Properties
        [BindProperty]
        public OrderDTO Order { get; set; }
        public List<ItemOrderDTO> ItemOrders { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(int orderId)
        {
            Order = await _orderService.GetByIdAsync(orderId);
            ItemOrders = await _itemOrderService.GetAllByOrderId(orderId);

            await _orderService.CheckOrderStatus(ItemOrders, Order);
            Order.Customer = await _customerService.GetByIdAsync(Order.CustomerId);
            return Page();
        }
    }
}
