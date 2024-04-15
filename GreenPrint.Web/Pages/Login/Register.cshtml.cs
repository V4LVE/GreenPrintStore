using GreenPrint.Repository.Entities;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Service.Services;
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
            NewUser = await _userService.CreateAndReturn(NewUser);

            var session = await _sessionService.CreateSession(NewUser.Id);

            CookieOptions options = new() { Expires = session.ExpirationDate, Secure = true };



            string serializedSession = JsonSerializer.Serialize(session);
            Response.Cookies.Append("Session", serializedSession, options);

            return RedirectToPage("/Login/MyAccount", new { userId = NewUser.Id });
        }
    }   
}
