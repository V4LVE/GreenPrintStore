using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Order
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        #region
        private readonly IOrderService _OrderService;
        private readonly ILogger<OrderController> _logger;
        #endregion

        #region Constructor
        public OrderController(IOrderService OrderService, ILogger<OrderController> logger)
        {
            _OrderService = OrderService;
            _logger = logger;
        }
        #endregion





        [HttpGet("{OrderId:int}", Name = "GetOrder")]
        public async Task<IActionResult> GetOrder(int OrderId)
        {
            var temp = await _OrderService.GetByIdAsync(OrderId);

            if (temp != null)
            {
                temp.Customer.Orders = null;
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(OrderDTO Order)
        {
            try
            {
                Order = await _OrderService.CreateAndReturn(Order);
                return CreatedAtAction("GetOrder", new { OrderId = Order.Id }, Order);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete("{OrderId:int}")]
        [Route("remove")]
        public async Task<IActionResult> Remove(int OrderId)
        {
            var Order = await _OrderService.GetByIdAsync(OrderId);

            if (Order == null)
                return NotFound();

            try
            {
                await _OrderService.DeleteAsync(Order);
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
        public async Task<IActionResult> Edit(OrderDTO Order)
        {
            try
            {
                await _OrderService.UpdateAsync(Order);
                return CreatedAtAction("GetOrder", new { OrderId = Order.Id }, Order);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch("{OrderId:int}")]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int OrderId, [FromBody] JsonPatchDocument<OrderDTO> patchDocument)
        {
            var Order = await _OrderService.GetByIdAsync(OrderId);
            if (Order == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(Order);
                await _OrderService.UpdateAsync(Order);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetOrder", new { OrderId = Order.Id }, Order);
        }
    }
}
