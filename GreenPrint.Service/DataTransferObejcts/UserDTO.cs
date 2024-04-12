using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class UserDTO
    {
        [Key]
        public int Id { get; set; }
        public string Password { get; set; }

        // Todo: Add hash and salt instead of plain text password
        public string Email { get; set; }
        public int Roleid { get; set; }
        public int? CustomerId { get; set; }

        // Navigation properties
        public RoleDTO? Role { get; set; }
        public CustomerDTO? Customer { get; set; }

    }
}
