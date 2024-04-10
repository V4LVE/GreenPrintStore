using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GreenPrint.Web.Pages.Admin.Accounts
{
    public class CustomersModel : PageModel
    {
        #region backing Fields
        private readonly ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomersModel(ICustomerService customerService)
        {
            _customerService = customerService; 
        }
        #endregion

        #region Properties
        public List<CustomerDTO> Customers { get; set; }
        #endregion

        public async Task<IActionResult> OnGet()
        {
            Customers = await _customerService.GetAllAsync();

            return Page();
        }
    }
}
