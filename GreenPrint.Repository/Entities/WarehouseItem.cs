using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Entities
{
    public class WarehouseItem
    {
        [Key]
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Warehouse Warehouse { get; set; }
        public Item Item { get; set; }
    }
}
