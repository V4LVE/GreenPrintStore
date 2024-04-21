using GreenPrint.Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class ItemOrderDTO
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public OrderStatusEnum Status { get; set; }

        // Navigation Properties
        public ItemDTO? Item { get; set; }
        public OrderDTO? Order { get; set; }
        public WarehouseDTO? Warehouse { get; set; }
    }
}
