using GreenPrint.Repository.Enums;
using GreenPrint.Repository.Paging;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GreenPrint.Web.Pages.Items
{
    public enum PageSizeEnum
    {
        [Display(Name = "8")]
        _8 = 8,
        [Display(Name = "16")]
        _16 = 16,
        [Display(Name = "32")]
        _32 = 32,
    }

    public class ItemListViewModel : PageModel
    {
        #region Constructor
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        private readonly IWarehouseItemService _warehouseItemService;
        public ItemListViewModel(IItemService itemService, ICategoryService categoryService, IWarehouseItemService warehouseItemService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
            _warehouseItemService = warehouseItemService;
        }
        #endregion
        [BindProperty(SupportsGet = true)]
        public PageOptions OptionsPaging { get; set; } = new();

        [BindProperty(SupportsGet =true)]
        public OrderByOptionsItem OrderBy { get; set; } = OrderByOptionsItem.PriceAsc;


        public List<ItemDTO> Items { get; set; }
        public CategoryDTO Category { get; set; }

        public async Task<IActionResult> OnGet(int categoryID)
        {
            Items = await _itemService.GetItemsByCategory(categoryID, OptionsPaging, OrderBy);
            Category = await _categoryService.GetByIdAsync(categoryID);
            OptionsPaging.TotalPages = (int)Math.Ceiling(decimal.Divide(_itemService.GetAllAsync().Result.Count, OptionsPaging.PageSize));
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
