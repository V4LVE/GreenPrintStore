using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Enums
{
    public enum OrderByOptionsItem
    {
        [Display(Name = "Order Id Descending ↓")]
        IDDes = 0,
        [Display(Name = "Order Id Ascending ↑")]
        IDAsc,
        [Display(Name = "Price ↓")]
        PriceDes,
        [Display(Name = "Price ↑")]
        PriceAsc
    }
}
