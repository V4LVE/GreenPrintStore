using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Order
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        #region
        private readonly IOrderService _OrderService;
        private readonly ILogger<OrdersController> _logger;
        #endregion

        #region Constructor
        public OrdersController(IOrderService OrderService, ILogger<OrdersController> logger)
        {
            _OrderService = OrderService;
            _logger = logger;
        }
        #endregion





        [HttpGet]
        public async Task<IEnumerable<OrderDTO>> Get()
        {
            return await _OrderService.GetAllAsync();
        }
    }
}
