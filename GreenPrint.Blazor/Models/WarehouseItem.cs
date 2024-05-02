using System.ComponentModel.DataAnnotations;

namespace GreenPrint.Blazor.Models
{
    public class WarehouseItem
    {
        public int Id { get; set; }
        [Required, Range(1, 99999999999, ErrorMessage = "You must select a warehouse")]
        public int WarehouseId { get; set; }
        [Required]
        public int ItemId { get; set; }
        [Required, Range(1,1000000000, ErrorMessage = "You cannot add zero or negative stock")]
        public int Quantity { get; set; }

        // Navigation properties
        public Warehouse Warehouse { get; set; }
        public Item Item { get; set; }
    }
}
