using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Admin.Accounts
{
    public class CustomerModel : PageModel
    {
        #region backing Fields
        private readonly ICustomerService _customerService;
        #endregion

        #region Constructor
        public CustomerModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        #endregion

        #region Properties
        [BindProperty]
        public CustomerDTO Customer { get; set; }
        #endregion

        public async Task<IActionResult> OnGet(int customerId)
        {
            if (!await HttpContext.AuthenticatedUserIsAdmin())
            {
                return RedirectToPage("/UnAuthorized");
            }

            Customer = await _customerService.GetByIdAsync(customerId);

            if (Customer != null)
            {
                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostUpdateAsync()
        {
            if (ModelState.IsValid)
            {
                await _customerService.UpdateAsync(Customer);
                return RedirectToPage("/Admin/Accounts/Customers");
            }

            return Page(); 
        }
    }
}
