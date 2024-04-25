using GreenPrint.Blazor.Models.Enums;

namespace GreenPrint.Blazor.Models
{
    public class ItemOrder
    {
        public int Id { get; set; }
        public int ItemId { get; set; }
        public int OrderId { get; set; }
        public int WarehouseId { get; set; }
        public int Quantity { get; set; }
        public OrderStatusEnum Status { get; set; }

        // Navigation Properties
        public Item Item { get; set; }
        public Order Order { get; set; }
        public Warehouse? Warehouse { get; set; }
    }
}
