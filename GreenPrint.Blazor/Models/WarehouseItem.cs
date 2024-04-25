namespace GreenPrint.Blazor.Models
{
    public class WarehouseItem
    {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }

        // Navigation properties
        public Warehouse Warehouse { get; set; }
        public Item Item { get; set; }
    }
}
