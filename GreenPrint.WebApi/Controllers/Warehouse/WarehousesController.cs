using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Warehouse
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WarehousesController : ControllerBase
    {
        #region
        private readonly IWarehouseService _warehouseService;
        private readonly ILogger<WarehousesController> _logger;
        #endregion

        #region Constructor
        public WarehousesController(IWarehouseService warehouseService, ILogger<WarehousesController> logger)
        {
            _warehouseService = warehouseService;
            _logger = logger;
        }
        #endregion





        [HttpGet]
        public async Task<IEnumerable<WarehouseDTO>> Get()
        {
            return await _warehouseService.GetAllAsync();
        }
    }
}
