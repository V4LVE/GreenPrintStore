using GreenPrint.Repository.Paging;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GreenPrint.Web.Pages
{

    public class IndexModel : PageModel
    {
        #region backing fields
        private readonly ILogger<IndexModel> _logger;
        private readonly ICategoryService _categoryService;
        private readonly IItemService _itemService;
        #endregion

        #region Constructor
        public IndexModel(ILogger<IndexModel> logger, ICategoryService categoryService, IItemService itemService)
        {
            _logger = logger;
            _categoryService = categoryService;
            _itemService = itemService;
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
    }
}
