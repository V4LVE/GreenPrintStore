using GreenPrint.Repository.Paging;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace GreenPrint.Web.Pages.Items
{
    public class ItemModel : PageModel
    {
        #region Services
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseItemService _warehouseItemService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        #endregion

        #region constructor
        public ItemModel(IItemService itemService, ICategoryService categoryService, IWarehouseItemService warehouseItemService, IWebHostEnvironment webHostEnvironment)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _warehouseItemService = warehouseItemService;
            _webHostEnvironment = webHostEnvironment;
        }
        #endregion

        #region Properties
        [BindProperty]
        public ItemDTO Item { get; set; }
        [BindProperty]
        public List<WarehouseItemDTO> Stock { get; set; }
        [BindProperty]
        public List<ItemDTO> SuggestedItems { get; set; }
        [BindProperty]
        public PageOptions OptionsPaging { get; set; } = new();
        #endregion
        public async Task<IActionResult> OnGet(int itemId)
        {
            Item = await _itemService.GetByIdAsync(itemId);
            if (Item == null)
            {
                return NotFound();
            }

            Stock = await _warehouseItemService.GetAllByByItemId(itemId);
            SuggestedItems = await _itemService.GetItemsByCategory(itemId, OptionsPaging);
            
            return Page();
        }

        public async Task<IActionResult> OnPostAddToCartAsync(int itemId)
        {
            var item = await _itemService.GetByIdAsync(itemId);
            var warehouseItems = await _warehouseItemService.GetAllByByItemId(itemId);
            List<WarehouseItemDTO> ordredItems = new();

            string ItemCartCookie = Request.Cookies["ItemCartCookie"];
            CookieOptions cookieOptions = new() { Expires = DateTime.Now.AddDays(3) };

            if (ItemCartCookie == null)
            {
                ordredItems.Add(new()
                {
                    Id = warehouseItems[0].Id,
                    WarehouseId = warehouseItems[0].WarehouseId,
                    ItemId = itemId,
                    Quantity = 1
                });

                string serializedItems = JsonSerializer.Serialize(ordredItems);

                Response.Cookies.Append("ItemCartCookie", serializedItems, cookieOptions);
            } // If cookie exists
            else
            {
                ordredItems = JsonSerializer.Deserialize<List<WarehouseItemDTO>>(ItemCartCookie);

                // Check if the item is already in the cart
                if (ordredItems.Where(wp => wp.ItemId == itemId).Any())
                {
                    ordredItems.Single(wp => wp.ItemId == itemId).Quantity++;
                } // Else add it to the cart
                else
                {
                    ordredItems.Add(new()
                    {
                        Id = warehouseItems[0].Id,
                        WarehouseId = warehouseItems[0].WarehouseId,
                        ItemId = itemId,
                        Quantity = 1
                    });
                }
                string serializedItems = JsonSerializer.Serialize(ordredItems);
                Response.Cookies.Append("ItemCartCookie", serializedItems, cookieOptions);
            }



            return RedirectToPage();
        }
    }
}
