using GreenPrint.Repository.Entities;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Service.Services;
using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace GreenPrint.Web.Pages.Login
{
    public class RegisterModel : PageModel
    {
        #region Services
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private readonly ISessionService _sessionService;
        #endregion

        #region Constructor
        public RegisterModel(IUserService userService, ICustomerService customerService, ISessionService sessionService)
        {
            _userService = userService;
            _customerService = customerService;
            _sessionService = sessionService;
        }
        #endregion

        #region Properties
        [BindProperty]
        public UserDTO NewUser { get; set; }
        [BindProperty]
        public string PassConfirm { get; set; }
        #endregion

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostCreateUserAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (await _userService.GetUserByEmailAsync(NewUser.Email) != null)
            {
                ModelState.AddModelError("NewUser.Email", "This email already exists. Please login instead");
                return Page();
            }
            if (NewUser.Password != PassConfirm)
            {
                ModelState.AddModelError("NewUser.Password", "Passwords do not match");
                return Page();
            }

            NewUser.Roleid = 1;
            NewUser.Customer = new CustomerDTO();
            NewUser = await _userService.CreateAndReturn(NewUser);

            return RedirectToPage("/Login/Login");
        }
    }   
}
