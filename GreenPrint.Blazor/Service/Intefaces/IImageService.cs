using GreenPrint.Blazor.Models;

namespace GreenPrint.Blazor.Service.Intefaces
{
    public interface IImageService
    {
        /// <summary>
        /// Get all images by item id
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task <List<ItemImage>> GetAllByItemId(int itemId);
    }
}
