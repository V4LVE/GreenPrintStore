using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class WarehouseItemDTO
    {
        [Key]
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public WarehouseDTO Warehouse { get; set; }
        public ItemDTO Item { get; set; }
    }
}
