using GreenPrint.Repository.Entities;
using GreenPrint.Repository.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Filtering.Orders
{


    public static class ItemSorting
    {
        public static IQueryable<Item> OrderItemsBy(this IQueryable<Item> item, OrderByOptionsItem orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptionsItem.IDDes:
                    return item.OrderByDescending(x => x.Id);

                case OrderByOptionsItem.IDAsc:
                    return item.OrderBy(x => x.Id);

                case OrderByOptionsItem.PriceAsc:
                    return item.OrderBy(x => x.Price);

                case OrderByOptionsItem.PriceDes:
                    return item.OrderByDescending(x => x.Price);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }

    }
}
