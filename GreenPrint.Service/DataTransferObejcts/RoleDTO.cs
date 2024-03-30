using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class RoleDTO
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; }

        // Navigation Properties
        public List<UserDTO> Users { get; set; }
    }
}
