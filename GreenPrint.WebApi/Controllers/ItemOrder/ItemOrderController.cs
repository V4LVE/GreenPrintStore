using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Service.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.ItemOrder
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ItemOrderController : ControllerBase
    {
        #region
        private readonly IItemOrderService _ItemOrderService;
        private readonly ILogger<ItemOrderController> _logger;
        #endregion

        #region Constructor
        public ItemOrderController(IItemOrderService ItemOrderService, ILogger<ItemOrderController> logger)
        {
            _ItemOrderService = ItemOrderService;
            _logger = logger;
        }
        #endregion





        [HttpGet("{orderId:int}", Name = "GetItemOrders")]
        public async Task<IActionResult> GetItemOrdersByOrderId(int orderId)
        {
            var temp = await _ItemOrderService.GetAllByOrderId(orderId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(List<ItemOrderDTO> itemOrders)
        {
            try
            {
                await _ItemOrderService.CreateListAsync(itemOrders);
                return CreatedAtAction("GetItemOrders", itemOrders);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove/{ItemOrderId:int}")]
        public async Task<IActionResult> Remove(int ItemOrderId)
        {
            var ItemOrder = await _ItemOrderService.GetByIdAsync(ItemOrderId);

            if (ItemOrder == null)
                return NotFound();

            try
            {
                await _ItemOrderService.DeleteAsync(ItemOrder);
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
        public async Task<IActionResult> Edit(ItemOrderDTO ItemOrder)
        {
            try
            {
                await _ItemOrderService.UpdateAsync(ItemOrder);
                return CreatedAtAction("GetItemOrder", new { ItemOrderId = ItemOrder.Id }, ItemOrder);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch]
        [Route("update/{ItemOrderId:int}")]
        public async Task<IActionResult> EditPartially(int ItemOrderId, [FromBody] JsonPatchDocument<ItemOrderDTO> patchDocument)
        {
            var ItemOrder = await _ItemOrderService.GetByIdAsync(ItemOrderId);
            if (ItemOrder == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(ItemOrder);
                await _ItemOrderService.UpdateAsync(ItemOrder);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetItemOrder", new { ItemOrderId = ItemOrder.Id }, ItemOrder);
        }
    }
}
