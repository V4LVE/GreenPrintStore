using GreenPrint.Service.DataTransferObjects;

namespace GreenPrint.WebApi.Models
{
    public class UserModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public int Roleid { get; set; }

        public CustomerModel? Customer { get; set; }
    }
}
