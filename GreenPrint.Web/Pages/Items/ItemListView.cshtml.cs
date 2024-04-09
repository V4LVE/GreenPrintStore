using GreenPrint.Repository.Paging;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace GreenPrint.Web.Pages.Items
{
    public enum PageSizeEnum
    {
        [Display(Name = "5")]
        _5 = 5,
        [Display(Name = "10")]
        _10 = 10,
        [Display(Name = "25")]
        _25 = 25,
    }

    public class ItemListViewModel : PageModel
    {
        #region Constructor
        private readonly IItemService _itemService;
        private readonly ICategoryService _categoryService;
        public ItemListViewModel(IItemService itemService, ICategoryService categoryService)
        {
            _itemService = itemService;
            _categoryService = categoryService;
        }
        #endregion
        [BindProperty(SupportsGet = true)]
        public PageOptions OptionsPaging { get; set; } = new();


        public List<ItemDTO> Items { get; set; }
        public CategoryDTO Category { get; set; }

        public async Task<IActionResult> OnGet(int categoryID)
        {
            Items = await _itemService.GetItemsByCategory(categoryID, OptionsPaging);
            Category = await _categoryService.GetByIdAsync(categoryID);
            OptionsPaging.TotalPages = (int)Math.Ceiling(decimal.Divide(_itemService.GetAllAsync().Result.Count, OptionsPaging.PageSize));
            return Page();
        }
    }
}
