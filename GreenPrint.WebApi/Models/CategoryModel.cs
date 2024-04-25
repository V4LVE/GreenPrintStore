using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.WebApi.Models
{
    public class CategoryModel
    {
        [Required]
        public string CategoryName { get; set; }

    }
}
