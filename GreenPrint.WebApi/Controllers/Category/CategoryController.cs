using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
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





        [HttpGet(Name = "GetCategory")]
        public async Task<IActionResult> GetCategory(int CategoryId)
        {
            var temp = await _CategoryService.GetByIdAsync(CategoryId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(CategoryDTO Category)
        {
            try
            {
                Category = await _CategoryService.CreateAndReturn(Category);
                return CreatedAtAction("GetCategory", new { CategoryId = Category.Id }, Category);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove")]
        public async Task<IActionResult> Remove(int CategoryId)
        {
            var Category = await _CategoryService.GetByIdAsync(CategoryId);

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
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int CategoryId, [FromBody] JsonPatchDocument<CategoryDTO> patchDocument)
        {
            var Category = await _CategoryService.GetByIdAsync(CategoryId);
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
