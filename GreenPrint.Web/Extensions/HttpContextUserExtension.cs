﻿using Azure.Core;
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

        public static async Task<int> GetUser(this HttpContext context)
        {
            try
            {
                SessionDTO session = await GetSession(context);
                return session.UserId;
            }
            catch (Exception)
            {
                return 0;
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

        public static async Task<int> GetCartCount(this HttpContext context)
        {
            string jsoncartCookie = context.Request.Cookies["ItemCartCookie"];

            if (jsoncartCookie != null)
            {
                var tempitems = JsonSerializer.Deserialize<List<WarehouseItemDTO>>(jsoncartCookie);
                var totalCount = 0;
                foreach (var item in tempitems)
                {
                    totalCount += item.Quantity;
                }
                return totalCount;
            }

            return 0;
        }
    }
}
