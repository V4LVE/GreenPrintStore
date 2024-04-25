using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.WebApi.Models;
using GreenPrint.WebApi.ExtensionMethods;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Category
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        #region
        private readonly ICategoryService _CategoryService;
        private readonly ILogger<CategoryController> _logger;
        #endregion

        #region Constructor
        public CategoryController(ICategoryService CategoryService, ILogger<CategoryController> logger)
        {
            _CategoryService = CategoryService;
            _logger = logger;
        }
        #endregion





        [HttpGet("{categoryId:int}", Name = "GetCategory")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(CategoryDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCategory(int categoryId)
        {
            var temp = await _CategoryService.GetByIdAsync(categoryId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [Route("create")]
        public async Task<IActionResult> Create(CategoryModel Category)
        {
            var CategoryDto = Category.MapCategoryToDto();

            try
            {
                CategoryDto = await _CategoryService.CreateAndReturn(CategoryDto);
                return CreatedAtAction("GetCategory", new { CategoryId = CategoryDto.Id }, CategoryDto);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{categoryId:int}")]
        public async Task<IActionResult> Remove(int categoryId)
        {
            var Category = await _CategoryService.GetByIdAsync(categoryId);

            if (Category == null)
                return NotFound();

            try
            {
                await _CategoryService.DeleteAsync(Category);
                return NoContent(); // Success
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit(CategoryDTO Category)
        {
            try
            {
                await _CategoryService.UpdateAsync(Category);
                return CreatedAtAction("GetCategory", new { CategoryId = Category.Id }, Category);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update/{categoryId:int}")]
        public async Task<IActionResult> EditPartially(int categoryId, [FromBody] JsonPatchDocument<CategoryDTO> patchDocument)
        {
            var Category = await _CategoryService.GetByIdAsync(categoryId);
            if (Category == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(Category);
                await _CategoryService.UpdateAsync(Category);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetCategory", new { CategoryId = Category.Id }, Category);
        }
    }
}
