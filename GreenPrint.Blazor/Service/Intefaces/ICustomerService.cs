using GreenPrint.Blazor.Models;

namespace GreenPrint.Blazor.Service.Intefaces
{
    public interface ICustomerService
    {
        /// <summary>
        /// Creates a new customer
        /// </summary>
        /// <param name="Customer"></param>
        /// <returns></returns>
        public Task<Customer> CreateCustomer(Customer Customer);
    }
}
