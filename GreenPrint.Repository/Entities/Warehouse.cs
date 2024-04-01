using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Entities
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public int AddressId { get; set; }

        // Navigation Properties
        public List<WarehouseItem>? Items { get; set; }
        public List<ItemOrder>? ItemOrders { get; set; }
        public Address Address { get; set; }
    }
}
