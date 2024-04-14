using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class ItemDTO
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        // Navigation Properties
        public CategoryDTO Category { get; set; }
        public List<WarehouseItemDTO>? WarehouseItems { get; set; }
        public List<ItemImageDTO>? ItemImages { get; set; }
    }
}
