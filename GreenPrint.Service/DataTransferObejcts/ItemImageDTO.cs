using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class ItemImageDTO
    {
        [Key]
        public int Id { get; set; }
        public int ItemId { get; set; }
        public string ImageUrl { get; set; }
        public DateTime DateCreated { get; set; }

        // Navigation Properties
        public ItemDTO? Item { get; set; }
    }
}
