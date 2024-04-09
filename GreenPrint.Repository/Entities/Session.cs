using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPrint.Repository.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public Guid SessionToken { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UserId { get; set; }

        //navigation property
        public User User { get; set; }
    }
}
