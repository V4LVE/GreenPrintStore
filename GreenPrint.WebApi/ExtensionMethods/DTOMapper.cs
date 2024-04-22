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
    }
}
