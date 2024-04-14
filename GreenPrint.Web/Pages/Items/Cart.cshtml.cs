using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace GreenPrint.Web.Pages.Items
{
    public class CartModel : PageModel
    {
        #region backing Fields
        private readonly IItemService _itemService;
        private readonly IWarehouseItemService _warehouseItemService;
        private readonly IWarehouseService _warehouseService;
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;
        private readonly IUserService _userService;
        private readonly IItemOrderService _itemOrderService;
        #endregion

        #region Constructor
        public CartModel(IItemService itemService, IWarehouseItemService warehouseItemService, IWarehouseService warehouseService, IOrderService orderService, ICustomerService customerService, IUserService userService, IItemOrderService itemOrderService)
        {
            _itemService = itemService;
            _warehouseItemService = warehouseItemService;
            _warehouseService = warehouseService;
            _orderService = orderService;
            _customerService = customerService;
            _userService = userService;
            _itemOrderService = itemOrderService;
        }
        #endregion

        public List<WarehouseItemDTO> CookieItemProducts { get; set; } = new();
        public double TotalPrice { get; set; } = 0;
        public double ItemTotalPrice { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public double ShippingPrice { get; set; } = 59;
        public double DiscountDeduct { get; set; } = 0;
        public string DiscountCode { get; set; }

        [BindProperty]
        public UserDTO? NewUser { get; set; }
        [BindProperty]
        public CustomerDTO NewCustomer { get; set; }
        [BindProperty]
        public AddressDTO NewCustomerAddress { get; set; }
        [BindProperty]
        public OrderDTO NewOrder { get; set; }
        [BindProperty]
        public string? PassConfirm { get; set; }
        [BindProperty]
        public bool CreateUserAccount { get; set; } = false;

        public async Task<IActionResult> OnGet()
        {
            if (await HttpContext.IsLoggedIn())
            {
                var tempuser = await _userService.GetByIdAsync(await HttpContext.GetUser());
                NewCustomer = await _customerService.GetByIdAsync((int)tempuser.CustomerId);
                NewCustomerAddress = NewCustomer.Address;
            }
            if (Request.Cookies["ItemCartCookie"] != null)
            {
                CookieItemProducts = JsonSerializer.Deserialize<List<WarehouseItemDTO>>(Request.Cookies["ItemCartCookie"]);
            }

            for (int i = 0; i < CookieItemProducts.Count; i++)
            {
                CookieItemProducts[i].Warehouse = await _warehouseService.GetByIdAsync(CookieItemProducts[i].WarehouseId);
                CookieItemProducts[i].Item = await _itemService.GetByIdAsync(CookieItemProducts[i].ItemId);
                TotalPrice += CookieItemProducts[i].Item.Price * CookieItemProducts[i].Quantity;
                ItemTotalPrice = TotalPrice;
            }

            TotalPrice += ShippingPrice;

            if (TotalPrice > 10000)
            {
                DiscountDeduct = TotalPrice * 0.1;
                TotalPrice -= DiscountDeduct;
                DiscountCode = "10% Discount";
            }

            return Page();
        }

        public async Task<IActionResult> OnPostRemoveFromCartAsync(int itemId)
        {
            if (Request.Cookies["ItemCartCookie"] != null)
            {
                CookieItemProducts = JsonSerializer.Deserialize<List<WarehouseItemDTO>>(Request.Cookies["ItemCartCookie"]);
            }

            CookieItemProducts.RemoveAll(i => i.ItemId == itemId);

            Response.Cookies.Append("ItemCartCookie", JsonSerializer.Serialize(CookieItemProducts), new CookieOptions { Expires = DateTime.Now.AddDays(3) });

            return RedirectToPage();
        }
        

        public async Task<IActionResult> OnPostOrderAsync()
        {
            NewCustomer.Address = NewCustomerAddress;

            if (!ModelState.IsValid)
            {
                await OnGet();
                return Page();
            }
            List<ItemOrderDTO> itemOrders = new();

            // If user wants to create an account
            if (CreateUserAccount)
            {
                if (NewUser.Password != PassConfirm)
                {
                    ModelState.AddModelError("NewUser.Password", "Passwords do not match");

                    await OnGet();
                    return Page();
                }
                if (await _userService.GetUserByEmailAsync(NewUser.Email) != null)
                {
                    ModelState.AddModelError("NewUser.Email", "This email already exists. Please login instead");

                    await OnGet();
                    return Page();
                }
                NewCustomer = await _customerService.CreateAndReturn(NewCustomer);
                NewUser.Roleid = 1;
                NewUser.CustomerId = NewCustomer.Id;
                NewUser = await _userService.CreateAndReturn(NewUser);
            }
            if (NewCustomer.Id == 0)
            {
                NewCustomer = await _customerService.CreateAndReturn(NewCustomer);
            }

            if (Request.Cookies["ItemCartCookie"] != null)
            {
                CookieItemProducts = JsonSerializer.Deserialize<List<WarehouseItemDTO>>(Request.Cookies["ItemCartCookie"]);
            }

            NewOrder.CustomerId = NewCustomer.Id;
            NewOrder.OrderDate = DateTime.Now;
            NewOrder.Status = Repository.Enums.OrderStatusEnum.Created;

            NewOrder = await _orderService.CreateAndReturn(NewOrder);

           
           

            // add items to itemOrderlist
            foreach (WarehouseItemDTO item in CookieItemProducts)
            {
                if (await _warehouseItemService.CheckWarehouseStock(item.ItemId, item.Quantity))
                {
                    ItemOrderDTO newItemOrder = new()
                    {
                        ItemId = item.ItemId,
                        OrderId = NewOrder.Id,
                        Quantity = item.Quantity,
                        WarehouseId = item.WarehouseId,
                        Status = Repository.Enums.OrderStatusEnum.Created
                    };

                    itemOrders.Add(newItemOrder);
                }
            }

            // add items to order
            if (itemOrders.Count != 0)
            {
                await _itemOrderService.CreateListAsync(itemOrders);
            }

            // update stock
            foreach (WarehouseItemDTO item in CookieItemProducts)
            {
                WarehouseItemDTO warehouseItem = await _warehouseItemService.GetByItemAndWarehouseId(item.ItemId, item.WarehouseId);
                warehouseItem.Quantity -= item.Quantity;
                await _warehouseItemService.UpdateAsync(warehouseItem);
            }

            Response.Cookies.Delete("ItemCartCookie");

            return RedirectToPage("/Orders/Order", new { orderId = NewOrder.Id });

            
        }
    }
}
