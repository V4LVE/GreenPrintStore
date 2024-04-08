using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly IUserService _userService;
        private readonly ISessionService _sessionService;

        public LoginModel(IUserService userService, ISessionService sessionService)
        {
            _userService = userService;
            _sessionService = sessionService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLoginAsync(string email, string password)
        {
            if (await _userService.UserLoginAsync(email,password))
            {

            }

            return RedirectToPage("/Index");
        }
    }
}
