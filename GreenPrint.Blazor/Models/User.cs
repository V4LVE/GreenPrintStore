using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GreenPrint.Blazor.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password and Confirmation Password must match.")]
        public string PassConfirm { get; set; }

        // Todo: Add hash and salt instead of plain text password
        [Required]
        public string Email { get; set; }
        public int Roleid { get; set; }

        // Navigation properties
        public Role Role { get; set; }
        public Customer Customer { get; set; }
        public Session? Session { get; set; }
    }
}
