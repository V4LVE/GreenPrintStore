using System.Net;

namespace GreenPrint.Blazor.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public int AddressId { get; set; }

        // Navigation Properties
        public List<WarehouseItem>? Items { get; set; }
        public List<ItemOrder>? ItemOrders { get; set; }
        public Address Address { get; set; }
    }
}
