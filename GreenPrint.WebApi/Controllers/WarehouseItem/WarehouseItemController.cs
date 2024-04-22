using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.WarehouseItem
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WarehouseItemController : ControllerBase
    {
        #region
        private readonly IWarehouseItemService _WarehouseItemService;
        private readonly ILogger<WarehouseItemController> _logger;
        #endregion

        #region Constructor
        public WarehouseItemController(IWarehouseItemService WarehouseItemService, ILogger<WarehouseItemController> logger)
        {
            _WarehouseItemService = WarehouseItemService;
            _logger = logger;
        }
        #endregion

        [HttpGet("item/stock/{ItemId:int}/{amount:int}", Name = "CheckStock")]
        public async Task<IActionResult> CheckStock(int ItemId, int amount)
        {
            var temp = await _WarehouseItemService.CheckWarehouseStock(ItemId, amount);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }

        [HttpGet("item/{ItemId:int}", Name = "GetWarehouseItemByItemId")]
        public async Task<IActionResult> GetWarehouseItemByItemId(int ItemId)
        {
            var temp = await _WarehouseItemService.GetAllByByItemId(ItemId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }

        [HttpGet("{WarehouseItemId:int}", Name = "GetWarehouseItem")]
        public async Task<IActionResult> GetWarehouseItem(int WarehouseItemId)
        {
            var temp = await _WarehouseItemService.GetByIdAsync(WarehouseItemId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(WarehouseItemDTO WarehouseItem)
        {
            try
            {
                WarehouseItem = await _WarehouseItemService.CreateAndReturn(WarehouseItem);
                return CreatedAtAction("GetWarehouseItem", new { WarehouseItemId = WarehouseItem.Id }, WarehouseItem);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{WarehouseItemId:int}")]
        public async Task<IActionResult> Remove(int WarehouseItemId)
        {
            var WarehouseItem = await _WarehouseItemService.GetByIdAsync(WarehouseItemId);

            if (WarehouseItem == null)
                return NotFound();

            try
            {
                await _WarehouseItemService.DeleteAsync(WarehouseItem);
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
        public async Task<IActionResult> Edit(WarehouseItemDTO WarehouseItem)
        {
            try
            {
                await _WarehouseItemService.UpdateAsync(WarehouseItem);
                return CreatedAtAction("GetWarehouseItem", new { WarehouseItemId = WarehouseItem.Id }, WarehouseItem);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update/{WarehouseItemId:int}")]
        public async Task<IActionResult> EditPartially(int WarehouseItemId, [FromBody] JsonPatchDocument<WarehouseItemDTO> patchDocument)
        {
            var WarehouseItem = await _WarehouseItemService.GetByIdAsync(WarehouseItemId);
            if (WarehouseItem == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(WarehouseItem);
                await _WarehouseItemService.UpdateAsync(WarehouseItem);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetWarehouseItem", new { WarehouseItemId = WarehouseItem.Id }, WarehouseItem);
        }
    }
}
