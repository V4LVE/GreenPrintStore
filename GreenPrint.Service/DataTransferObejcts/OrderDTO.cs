using GreenPrint.Repository.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class OrderDTO
    {
        [Key]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatusEnum Status { get; set; }

        // Navigation properties
        public List<ItemOrderDTO>? ItemOrders { get; set; }
        public CustomerDTO Customer { get; set; }
    }
}
