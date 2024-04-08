using GreenPrint.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GreenPrint.Web.Extensions
{
    public static class HttpContextUserExtension
    {

  
            


        public static async Task<bool> AuthenticatedUserIsAdmin(this HttpContext context)
        {
            IUserService userService = context.RequestServices.GetService<IUserService>();
            var user = await userService.GetUserByEmailAsync(context.User.Identity.Name);
            return await userService.IsUserAdminAsync(user.Id);
        }
    }
}
