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
                CategoryId = item.CategoryId,
                ItemImages = item.Images.MapItemImageToDto()
            };
        }

        public static List<ItemOrderDTO> MapItemOrderToDto(this List<ItemOrderModel> itemOrder)
        {
            List<ItemOrderDTO> itemOrderDTOs = new();

            foreach (var item in itemOrder)
            {
                itemOrderDTOs.Add(new ItemOrderDTO
                {
                    ItemId = item.ItemId,
                    OrderId = item.OrderId,
                    Quantity = item.Quantity,
                    WarehouseId = item.WarehouseId,
                    Status = item.Status
                });
            }

            return itemOrderDTOs;
        }

       public static OrderDTO MapOrderToDto(this OrderModel order)
        {
            return new OrderDTO
            {
                OrderDate = order.OrderDate,
                Status = order.Status,
                CustomerId = order.CustomerId
            };
        }

        public static RoleDTO MapRoleToDto(this RoleModel role)
        {
            return new RoleDTO
            {
                RoleName = role.RoleName
            };
        }

        public static UserDTO MapUserToDto(this UserModel user)
        {
            return new UserDTO
            {
                Email = user.Email,
                Password = user.Password,
                Roleid = user.Roleid
            };
        }

        public static WarehouseDTO MapWarehouseToDto(this WarehouseModel warehouse)
        {
            return new WarehouseDTO
            {
                WarehouseName = warehouse.WarehouseName,
                Address = warehouse.Address.MapAddressToDto()
            };
        }

        public static WarehouseItemDTO MapWarehouseItemToDto(this WarehouseItemModel warehouseItem)
        {
            return new WarehouseItemDTO
            {
                WarehouseId = warehouseItem.WarehouseId,
                ItemId = warehouseItem.ItemId,
                Quantity = warehouseItem.Quantity
            };
        }



        public static AddressDTO MapAddressToDto(this AddressModel address)
        {
            return new AddressDTO
            {
                StreetName = address.StreetName,
                StreetNumber = address.StreetNumber,
                City = address.City,
                ZipCode = address.ZipCode
            };
        }

        public static List<ItemImageDTO> MapItemImageToDto(this List<ImageModel> itemImages)
        {
            List<ItemImageDTO> itemImagesDto = new();

            if (itemImages != null)
            {
                foreach (var item in itemImages)
                {
                    itemImagesDto.Add(new ItemImageDTO
                    {
                        ItemId = item.ItemId,
                        ImageUrl = item.ImageUrl,
                        DateCreated = item.DateCreated
                    });
                }
            }

            return itemImagesDto;
        }

        public static SessionDTO MapSessionToDto(this SessionModel session)
        {
            return new SessionDTO
            {
                UserId = session.UserId
            };
        }


    }
}
