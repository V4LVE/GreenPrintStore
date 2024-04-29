using GreenPrint.Blazor.Models;
using GreenPrint.Blazor.Service.Intefaces;
using GreenPrint.Blazor.Utility;
using System.Text.Json;

namespace GreenPrint.Blazor.Extensions
{
    public static class CartExtension
    {
        public static int CartCount { get; set; } = 0;


        public static async Task AddToCart(LocalStorage localStorage, IWarehouseItemService warehouseItemService, IItemService itemService, int itemId)
        {
           
            var warehouseItems = await warehouseItemService.GetAllByByItemId(itemId);

            string? storage = await localStorage.GetValueAsync<string>("Cart");
            List<WarehouseItem> ordredItems = new();

            if (storage == null)
            {
                ordredItems.Add(new()
                {
                    Id = warehouseItems[0].Id,
                    WarehouseId = warehouseItems[0].WarehouseId,
                    ItemId = itemId,
                    Item = await itemService.GetItemByIdAsync(itemId),
                    Quantity = 1
                });
                CartCount = ordredItems.Sum(wi => wi.Quantity);
                string serializedItems = JsonSerializer.Serialize(ordredItems);
                await localStorage.SetValueAsync("Cart", serializedItems);
            } // If cookie exists
            else
            {
                ordredItems = JsonSerializer.Deserialize<List<WarehouseItem>>(storage);

                // Check if the item is already in the cart
                if (ordredItems.Where(wp => wp.ItemId == itemId).Any())
                {
                    ordredItems.Single(wp => wp.ItemId == itemId).Quantity++;
                } // Else add it to the cart
                else
                {
                    ordredItems.Add(new()
                    {
                        Id = warehouseItems[0].Id,
                        WarehouseId = warehouseItems[0].WarehouseId,
                        ItemId = itemId,
                        Quantity = 1
                    });
                }

                CartCount = ordredItems.Sum(wi => wi.Quantity);
                string serializedItems = JsonSerializer.Serialize(ordredItems);
                await localStorage.SetValueAsync("Cart", serializedItems);
            }
        }
    }
}
