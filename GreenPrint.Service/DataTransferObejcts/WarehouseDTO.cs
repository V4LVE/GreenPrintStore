using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class WarehouseDTO
    {
        [Key]
        public int Id { get; set; }
        public string WarehouseName { get; set; }
        public AddressDTO Address { get; set; }

        // Navigation Properties
        public List<WarehouseItemDTO>? Items { get; set; }
    }
}
