using System.ComponentModel.DataAnnotations;

namespace GreenPrint.Blazor.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        public string StreetName { get; set; }
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public string ZipCode { get; set; }
        [Required]
        public string City { get; set; }
    }
}
