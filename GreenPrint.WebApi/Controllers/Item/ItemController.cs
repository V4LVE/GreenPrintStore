using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Item
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        #region
        private readonly IItemService _itemService;
        private readonly ILogger<ItemController> _logger;
        #endregion

        #region Constructor
        public ItemController(IItemService itemService, ILogger<ItemController> logger)
        {
            _itemService = itemService;
            _logger = logger;
        }
        #endregion





        [HttpGet("{itemId:int}", Name = "GetItem")]
        public async Task<IActionResult> GetItem(int itemId)
        {
            var temp = await _itemService.GetByIdAsync(itemId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(ItemDTO item)
        {
            try
            {
                item = await _itemService.CreateAndReturn(item);
                return CreatedAtAction("GetItem", new { itemId = item.Id }, item);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete("{itemId:int}")]
        [Route("remove")]
        public async Task<IActionResult> Remove(int itemId)
        {
            var item = await _itemService.GetByIdAsync(itemId);

            if (item == null)
                return NotFound();

            try
            {
                await _itemService.DeleteAsync(item);
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
        public async Task<IActionResult> Edit(ItemDTO item)
        {
            try
            {
                await _itemService.UpdateAsync(item);
                return CreatedAtAction("GetItem", new { itemId = item.Id }, item);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch("{itemId:int}")]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int itemId, [FromBody] JsonPatchDocument<ItemDTO> patchDocument)
        {
            var item = await _itemService.GetByIdAsync(itemId);
            if (item == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(item);
                await _itemService.UpdateAsync(item);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetItem", new { itemId = item.Id }, item);
        }
    }
}
