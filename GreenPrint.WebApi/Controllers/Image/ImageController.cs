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
    public class ImageController : ControllerBase
    {
        #region
        private readonly IItemImageService _ImageService;
        private readonly ILogger<ImageController> _logger;
        #endregion

        #region Constructor
        public ImageController(IItemImageService Imageervice, ILogger<ImageController> logger)
        {
            _ImageService = Imageervice;
            _logger = logger;
        }
        #endregion





        [HttpGet]
        [Route("GetImagesById/{itemId:int}")]
        public async Task<IEnumerable<ItemImageDTO>> Get(int itemId)
        {
            return await _ImageService.GetAllImagesByItemId(itemId);
        }
    }
}
