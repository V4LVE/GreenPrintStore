using System.Data;

namespace GreenPrint.Blazor.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }

        // Todo: Add hash and salt instead of plain text password
        public string Email { get; set; }
        public int Roleid { get; set; }

        // Navigation properties
        public Role Role { get; set; }
        public Customer Customer { get; set; }
        public Session? Session { get; set; }
    }
}
