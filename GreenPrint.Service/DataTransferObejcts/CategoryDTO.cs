using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class CategoryDTO
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }

        // Navigation Properties
        public List<ItemDTO> Items { get; set; }

    }
}
