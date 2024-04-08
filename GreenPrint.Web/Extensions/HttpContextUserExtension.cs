using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Text.Json;

namespace GreenPrint.Web.Extensions
{
    public static class HttpContextUserExtension
    {

        public static async Task<string> GetUser(this HttpContext context)
        {
            IUserService userService = context.RequestServices.GetService<IUserService>();

            try
            {
                SessionDTO session = JsonSerializer.Deserialize<SessionDTO>(context.Request.Cookies["Session"]);
                return userService.GetByIdAsync(session.UserId).Result.Email;
            }
            catch (Exception)
            {
                return "Not logged in";
            }
        }
            


        public static async Task<bool> AuthenticatedUserIsAdmin(this HttpContext context)
        {
            IUserService userService = context.RequestServices.GetService<IUserService>();
            var user = await userService.GetUserByEmailAsync(context.User.Identity.Name);
            return await userService.IsUserAdminAsync(user.Id);
        }
    }
}
