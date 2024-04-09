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
        #endregion

        #region Constructor
        public IndexModel(ILogger<IndexModel> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }
        #endregion

        public List<CategoryDTO> Categories { get; set; }


        public async Task<IActionResult> OnGet()
        {
            Categories = await _categoryService.GetAllAsync();

            return Page();
        }
    }
}
