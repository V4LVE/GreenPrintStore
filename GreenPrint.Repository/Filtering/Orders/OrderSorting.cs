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


    public static class OrderSorting
    {
        public static IQueryable<Order> OrderOrdersBy(this IQueryable<Order> order, OrderByOptionsOrder orderByOptions)
        {
            switch (orderByOptions)
            {
                case OrderByOptionsOrder.IDDes:
                    return order.OrderByDescending(x => x.Id);

                case OrderByOptionsOrder.IDAsc:
                    return order.OrderBy(x => x.Id);

                case OrderByOptionsOrder.DateAsc:
                    return order.OrderBy(x => x.OrderDate);

                case OrderByOptionsOrder.DateDes:
                    return order.OrderByDescending(x => x.OrderDate);

                default:
                    throw new ArgumentOutOfRangeException(nameof(orderByOptions), orderByOptions, null);
            }
        }

    }
}
