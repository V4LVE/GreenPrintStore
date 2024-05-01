using System.ComponentModel.DataAnnotations;

namespace GreenPrint.Blazor.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required]
        public string ItemName { get; set; }
        [Required]
        public string Description { get; set; }
        [Required, Range(1,9999999999, ErrorMessage = "Price Cannot be negative") ]
        public double Price { get; set; }
        [Required]
        public int CategoryId { get; set; }

        // Navigation Properties
        public Category Category { get; set; }
        public List<WarehouseItem>? WarehouseItems { get; set; }
        public List<ItemImage>? ItemImages { get; set; }
    }
}
