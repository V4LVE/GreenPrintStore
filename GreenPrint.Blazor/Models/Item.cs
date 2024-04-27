namespace GreenPrint.Blazor.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        // Navigation Properties
        public Category Category { get; set; }
        public List<WarehouseItem>? WarehouseItems { get; set; }
        public List<ItemImage>? ItemImages { get; set; }
    }
}
