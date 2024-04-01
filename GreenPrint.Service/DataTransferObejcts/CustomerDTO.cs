using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class CustomerDTO
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Navigation properties
        public AddressDTO Address { get; set; }
        public List<OrderDTO> Orders { get; set; }
        public UserDTO User { get; set; }
    }
}
