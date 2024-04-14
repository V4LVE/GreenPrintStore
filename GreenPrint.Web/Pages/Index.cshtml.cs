using GreenPrint.Repository.Paging;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace GreenPrint.Web.Pages
{

    public class IndexModel : PageModel
    {
        #region backing fields
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IItemService _itemService;
        private readonly IWarehouseItemService _warehouseItemService;
        #endregion

        #region Constructor
        public IndexModel(ILogger<IndexModel> logger, ICategoryService categoryService, IItemService itemService, IWarehouseItemService warehouseItemService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _itemService = itemService;
            _warehouseItemService = warehouseItemService;
        }
        #endregion

        public List<CategoryDTO> Categories { get; set; }
        public List<ItemDTO> Items { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Categories = await _categoryService.GetAllAsync();
            Items = await _itemService.GetAllAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostSearchAsync(string searchQuery)
        {
            if (int.TryParse(searchQuery, out _))
            {
                return RedirectToPage("Items/Item", new { itemId = searchQuery });
            }
            else
            {
                return RedirectToPage("/items/SearchResult", new { SearchQuery = searchQuery });
            }
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
