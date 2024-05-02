using System.ComponentModel.DataAnnotations;

namespace GreenPrint.Blazor.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Email { get; set; }
        public int? AddressId { get; set; }
        [Required]
        public string Phone { get; set; }
        public int UserId { get; set; }

        // Navigation properties
        public Address? Address { get; set; }
        public List<Order>? Orders { get; set; }
        public User User { get; set; }
    }
}
