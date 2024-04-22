using GreenPrint.Service.DataTransferObjects;
using GreenPrint.WebApi.Models;
using System.Reflection.Metadata;

namespace GreenPrint.WebApi.ExtensionMethods
{
    public static class DTOMapper
    {
        public static CategoryDTO MapCategoryToDto(this CategoryModel category)
        {
            return new CategoryDTO
            {
                CategoryName = category.CategoryName
            };
        }

        public static ItemDTO MapItemToDto(this ItemModel item)
        {
            return new ItemDTO
            {
                ItemName = item.ItemName,
                Description = item.Description,
                Price = item.Price,
                CategoryId = item.CategoryId
            };
        }
    }
}
