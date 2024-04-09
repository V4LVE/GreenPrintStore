using GreenPrint.Web.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GreenPrint.Web.Pages.Admin
{
    public class AdminDashboardModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            if (!await HttpContext.AuthenticatedUserIsAdmin())
            {
                return RedirectToPage("/UnAuthorized");
            }

            return Page();
        }
    }
}
