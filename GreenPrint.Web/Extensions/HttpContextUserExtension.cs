using Azure.Core;
using GreenPrint.Repository.Entities;
using GreenPrint.Service.DataTransferObjects;
using GreenPrint.Service.Interfaces;
using GreenPrint.Service.Services;
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
                SessionDTO session = await GetSession(context);
                return userService.GetByIdAsync(session.UserId).Result.Email;
            }
            catch (Exception)
            {
                return "Not logged in";
            }
        }
        
        public static async Task<bool> IsLoggedIn(this HttpContext context)
        {
            ISessionService sessionService = context.RequestServices.GetService<ISessionService>();
            try
            {
                SessionDTO session = await GetSession(context);

                return await sessionService.CheckSession(session.Id);
            }
            catch (Exception)
            {
                return false;
            }
        }


        public static async Task<bool> AuthenticatedUserIsAdmin(this HttpContext context)
        {
            IUserService userService = context.RequestServices.GetService<IUserService>();
            ISessionService sessionService = context.RequestServices.GetService<ISessionService>();

            try
            {
                SessionDTO session = await GetSession(context);

                if (await sessionService.CheckSession(session.Id))
                {
                    return await userService.IsUserAdminAsync(session.UserId);
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }

            

            
        }

        public static async Task<SessionDTO> GetSession(this HttpContext context)
        {
           
            return JsonSerializer.Deserialize<SessionDTO>(context.Request.Cookies["Session"]);
        }
    }
}
