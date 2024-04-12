using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
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
        #endregion

        #region Constructor
        public CartModel(IItemService itemService, IWarehouseItemService warehouseItemService, IWarehouseService warehouseService)
        {
            _itemService = itemService;
            _warehouseItemService = warehouseItemService;
            _warehouseService = warehouseService;
        }
        #endregion

        public List<WarehouseItemDTO> CookieItemProducts { get; set; } = new();
        public double TotalPrice { get; set; } = 0;
        public double ItemTotalPrice { get; set; } = 0;
        [BindProperty(SupportsGet = true)]
        public double ShippingPrice { get; set; } = 59;
        public double DiscountDeduct { get; set; } = 0;
        public string DiscountCode { get; set; }

        public async Task<IActionResult> OnGet()
        {
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
    }
}
