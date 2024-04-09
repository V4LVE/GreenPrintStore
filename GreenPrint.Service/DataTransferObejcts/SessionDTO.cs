using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Service.DataTransferObjects
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public Guid SessionToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }

        //navigation property
        public UserDTO User { get; set; }
    }
}
