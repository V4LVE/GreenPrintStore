using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;

namespace GreenPrint.WebApi.Authentication
{
    public class ApiKeyAuthHandler(
        IOptionsMonitor<ApiKeyAuthOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock) : AuthenticationHandler<ApiKeyAuthOptions>(options, logger, encoder, clock)
    {
        const string ApiKeyIdentifier = "apikey";

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            string key = string.Empty;

            if (Request.Headers[ApiKeyIdentifier].Count != 0)
            {
                key = Request.Headers[ApiKeyIdentifier].FirstOrDefault();
            }
            else if (Request.Query.ContainsKey(ApiKeyIdentifier))
            {
                if (Request.Query.TryGetValue(ApiKeyIdentifier, out var queryKey))
                    key = queryKey;
            }

            if (string.IsNullOrWhiteSpace(key))
                return Task.FromResult(AuthenticateResult.Fail("No api key provided"));

            if (!string.Equals(key, Options.ApiKey, StringComparison.Ordinal))
                return Task.FromResult(AuthenticateResult.Fail("Invalid api key."));

            var identities = new List<ClaimsIdentity> { new("ApiKeyIdentity") };

            var ticket = new AuthenticationTicket(new ClaimsPrincipal(identities), Options.Scheme);

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}

