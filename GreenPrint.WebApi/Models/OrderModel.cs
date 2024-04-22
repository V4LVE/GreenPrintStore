using GreenPrint.Repository.Enums;
using GreenPrint.Service.DataTransferObjects;

namespace GreenPrint.WebApi.Models
{
    public class OrderModel
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatusEnum Status { get; set; }

    }
}
