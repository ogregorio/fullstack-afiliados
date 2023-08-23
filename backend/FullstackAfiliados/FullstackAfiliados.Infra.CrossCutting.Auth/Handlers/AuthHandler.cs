using System.Security.Claims;
using System.Text.Encodings.Web;
using FullstackAfiliados.Infra.CrossCutting.Auth.Authorization;
using FullstackAfiliados.Infra.CrossCutting.Auth.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Handlers;

public class AuthHandler : AuthenticationHandler<AuthOptions>
{
    private readonly IJwtUtils _jwtUtils;

    public AuthHandler(IOptionsMonitor<AuthOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, IJwtUtils jwtUtils) : base(options, logger, encoder, clock)
    {
        _jwtUtils = jwtUtils;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        if (!Request.Headers.TryGetValue(Options.TokenHeader, out var authHeader))
            return AuthenticateResult.NoResult();

        var authHeaderValues = authHeader.FirstOrDefault()?.Split(' ');
        if (authHeaderValues == null || authHeaderValues.Length < 2)
            return AuthenticateResult.NoResult();

        var token = authHeaderValues[1];
        if (string.IsNullOrEmpty(token))
            return AuthenticateResult.NoResult();

        var claimsList = _jwtUtils.ValidateJwtToken(token);

        var identity = new ClaimsIdentity(claimsList, Scheme.Name);
        var principal = new ClaimsPrincipal(identity);

        return AuthenticateResult.Success(new AuthenticationTicket(principal, Scheme.Name));
    }
}