﻿using Microsoft.AspNetCore.Authentication;

namespace GreenPrint.WebApi.Authentication
{
    public class ApiKeyAuthOptions : AuthenticationSchemeOptions
    {
        public const string DefaultScheme = "ApiKey";
        public string Scheme => DefaultScheme;
        public string ApiKey { get; set; }
    }
}
