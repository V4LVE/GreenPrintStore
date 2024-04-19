using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Categorie
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoriesController : ControllerBase
    {
        #region
        private readonly ICategoryService _CategorieService;
        private readonly ILogger<CategoriesController> _logger;
        #endregion

        #region Constructor
        public CategoriesController(ICategoryService CategorieService, ILogger<CategoriesController> logger)
        {
            _CategorieService = CategorieService;
            _logger = logger;
        }
        #endregion





        [HttpGet]
        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            return await _CategorieService.GetAllAsync();
        }
    }
}
