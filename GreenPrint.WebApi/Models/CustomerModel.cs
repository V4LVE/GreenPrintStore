using GreenPrint.Service.DataTransferObjects;

namespace GreenPrint.WebApi.Models
{
    public class CustomerModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        internal List<CustomerDTO> MapCustomerToDto()
        {
            throw new NotImplementedException();
        }
    }
}
