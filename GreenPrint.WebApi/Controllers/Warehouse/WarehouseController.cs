using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Warehouse
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WarehouseController : ControllerBase
    {
        #region
        private readonly IWarehouseService _warehouseService;
        private readonly ILogger<WarehouseController> _logger;
        #endregion

        #region Constructor
        public WarehouseController(IWarehouseService warehouseService, ILogger<WarehouseController> logger)
        {
            _warehouseService = warehouseService;
            _logger = logger;
        }
        #endregion





        [HttpGet("{warehouseId:int}", Name = "GetWarehouse")]
        public async Task<IActionResult> GetWarehouse(int warehouseId)
        {
            var temp = await _warehouseService.GetByIdAsync(warehouseId);

            if (temp != null)
            {
                return Ok(temp);
            }

            return NotFound();
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> Create(WarehouseDTO warehouse)
        {
            try
            {
                warehouse = await _warehouseService.CreateAndReturn(warehouse);
                return CreatedAtAction("GetWarehouse", new { warehouseId = warehouse.Id }, warehouse);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpDelete("{warehouseId:int}")]
        [Route("remove")]
        public async Task<IActionResult> Remove(int warehouseId)
        {
            var warehouse = await _warehouseService.GetByIdAsync(warehouseId);

            if (warehouse == null)
                return NotFound();

            try
            {
                await _warehouseService.DeleteAsync(warehouse);
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
        public async Task<IActionResult> Edit(WarehouseDTO warehouse)
        {
            try
            {
                await _warehouseService.UpdateAsync(warehouse);
                return CreatedAtAction("GetWarehouse", new { warehouseId = warehouse.Id }, warehouse);
            }
            catch (Exception e)
            {
                return UnprocessableEntity(e.Message);
            }
        }

        [HttpPatch("{warehouseId:int}")]
        [Route("update")]
        public async Task<IActionResult> EditPartially(int warehouseId, [FromBody] JsonPatchDocument<WarehouseDTO> patchDocument)
        {
            var warehouse = await _warehouseService.GetByIdAsync(warehouseId);
            if (warehouse == null)
            {
                return NotFound();
            }

            try
            {
                patchDocument.ApplyTo(warehouse);
                await _warehouseService.UpdateAsync(warehouse);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return UnprocessableEntity(e.Message);
            }

            return CreatedAtAction("GetWarehouse", new { warehouseId = warehouse.Id }, warehouse);
        }
    }
}
