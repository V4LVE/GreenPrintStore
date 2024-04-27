using GreenPrint.Repository.Paging;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenPrint.WebApi.Controllers.Item
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        #region
        private readonly IItemService _ItemService;
        private readonly ILogger<ItemsController> _logger;
        #endregion

        #region Constructor
        public ItemsController(IItemService ItemService, ILogger<ItemsController> logger)
        {
            _ItemService = ItemService;
            _logger = logger;
        }
        #endregion





        [HttpGet]
        public async Task<IEnumerable<ItemDTO>> Get()
        {
            return await _ItemService.GetAllAsync();
        }

        [HttpGet]
        [Route("GetFeaturedItems")]
        public async Task<IEnumerable<ItemDTO>> GetFeatured()
        {
            return _ItemService.GetAllAsync().Result.Take(8);
        }

        [HttpGet]
        [Route("GetFeaturedItemsByCategory/{categoryId:int}/{page:int}/{pagesize:int}")]
        public async Task<IEnumerable<ItemDTO>> GetFeaturedByCategory(int categoryId, int page, int pagesize)
        {
            PageOptions pageOptions = new()
            {
                CurrentPage = page,
                PageSize = pagesize
            };

            return await _ItemService.GetItemsByCategory(categoryId, pageOptions);
        }
    }
}
