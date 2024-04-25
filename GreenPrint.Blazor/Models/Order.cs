using GreenPrint.Blazor.Models.Enums;

namespace GreenPrint.Blazor.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatusEnum Status { get; set; }

        // Navigation properties
        public List<ItemOrder>? ItemOrders { get; set; }
        public Customer Customer { get; set; }
    }
}
