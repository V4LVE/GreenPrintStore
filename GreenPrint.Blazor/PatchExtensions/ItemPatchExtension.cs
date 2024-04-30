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
            //var props = OldItem.GetType().GetProperties();

            //foreach (PropertyInfo propertyInfo in props)
            //{
            //    PropertyInfo correspondingProperty = NewItem.GetType().GetProperty(propertyInfo.Name);

            //    if (correspondingProperty != null)
            //    {
            //        object OldValue = propertyInfo.GetValue(OldItem);
            //        object NewValue = correspondingProperty.GetValue(NewItem);

            //        if (OldValue != NewValue)
            //        {
            //            patchdoc.Replace(p => propertyInfo.Name, NewValue);
            //        }
            //    }
            //}

            return patchdoc;
        }

    }
}
