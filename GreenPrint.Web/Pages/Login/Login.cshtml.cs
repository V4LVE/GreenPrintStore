using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

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
            string SessionCookie = Request.Cookies["Session"];
            if (SessionCookie != null)
            {
                _sessionService.CheckSession(JsonSerializer.Deserialize<SessionDTO>(SessionCookie).Id);
            }
        }

        public async Task<IActionResult> OnPostLoginAsync(string email, string password)
        {
            // If login is successful, create a session cookie
            if (await _userService.UserLoginAsync(email,password))
            {
                UserDTO user = await _userService.GetUserByEmailAsync(email);
                var session = await _sessionService.CreateSession(user.Id);

                CookieOptions options = new() { Expires = session.ExpirationDate, Secure = true };

                

                string serializedSession = JsonSerializer.Serialize(session);
                Response.Cookies.Append("Session", serializedSession, options);

                return RedirectToPage("/Index");
            }

            return RedirectToPage("ShowAlert", new {Message = "Your password or email was incorrect!", success = false});
        }
    }
}
