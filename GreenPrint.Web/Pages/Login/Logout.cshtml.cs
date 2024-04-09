using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace GreenPrint.Web.Pages.Login
{
    public class LogoutModel(ISessionService sessionService) : PageModel
    {
        private readonly ISessionService _sessionService = sessionService;

        public async Task<IActionResult> OnGet()
        {
            var cookie = JsonSerializer.Deserialize<SessionDTO>(Request.Cookies["Session"]);

            if (cookie != null)
            {
                await _sessionService.DeleteAsync(await _sessionService.GetByIdAsync(cookie.Id));
                Response.Cookies.Delete("Session");
            }

            return Page();
        }
    }
}
