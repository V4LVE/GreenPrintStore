using GreenPrint.Blazor.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Reflection;

namespace GreenPrint.Blazor.PatchExtensions
{
    public static class ItemPatchExtension
    {
        public static JsonPatchDocument<Item> PatchModel(this Item OldItem, Item NewItem)
        {

            if (NewItem == null)
            {
                return new JsonPatchDocument<Item>(); // No Changes
            }
            else if (OldItem == null)
            {
                return new JsonPatchDocument<Item>();
            }


            JsonPatchDocument<Item> patchdoc = new JsonPatchDocument<Item>();


            if (NewItem.ItemName != OldItem.ItemName)
            {
                patchdoc.Replace(p => p.ItemName, NewItem.ItemName);
            }
            if (NewItem.Description != OldItem.Description)
            {
                patchdoc.Replace(p => p.Description, NewItem.Description);
            }
            if (NewItem.Price != OldItem.Price)
            {
                patchdoc.Replace(p => p.Price, NewItem.Price);
            }
            if (NewItem.CategoryId != OldItem.CategoryId)
            {
                patchdoc.Replace(p => p.CategoryId, NewItem.CategoryId);
            }
            

            return patchdoc;
        }

        public static JsonPatchDocument<WarehouseItem> PatchModelW(this WarehouseItem OldItem, WarehouseItem NewItem)
        {

            if (NewItem == null)
            {
                return new JsonPatchDocument<WarehouseItem>(); // No Changes
            }
            else if (OldItem == null)
            {
                return new JsonPatchDocument<WarehouseItem>();
            }


            JsonPatchDocument<WarehouseItem> patchdoc = new JsonPatchDocument<WarehouseItem>();


            if (NewItem.ItemId != OldItem.ItemId)
            {
                patchdoc.Replace(p => p.ItemId, NewItem.ItemId);
            }
            if (NewItem.WarehouseId != OldItem.WarehouseId)
            {
                patchdoc.Replace(p => p.WarehouseId, NewItem.WarehouseId);
            }
            if (NewItem.Quantity != OldItem.Quantity)
            {
                patchdoc.Replace(p => p.Quantity, NewItem.Quantity);
            }



            return patchdoc;
        }

    }
}
