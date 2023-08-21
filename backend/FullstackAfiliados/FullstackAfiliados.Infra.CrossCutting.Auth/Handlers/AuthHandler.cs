using System.Text.Encodings.Web;
using FullstackAfiliados.Infra.CrossCutting.Auth.Handlers.Interfaces;
using FullstackAfiliados.Infra.CrossCutting.Auth.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Handlers;

public class AuthHandler : AuthenticationHandler<AuthOptions>
{
    private readonly IJwtTokenAuthHandler _jwtTokenAuthHandler;

    public AuthHandler(
        IOptionsMonitor<AuthOptions> options,
        ILoggerFactory logger,
        UrlEncoder encoder,
        ISystemClock clock,
        IJwtTokenAuthHandler jwtTokenAuthHandler
    ) : base(options, logger, encoder, clock)
    {
        _jwtTokenAuthHandler = jwtTokenAuthHandler;
    }

    protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
    {
        await HandleInitialize();
        var jwtTokenAuth = await _jwtTokenAuthHandler.AuthenticateAsync();
        if (jwtTokenAuth.Succeeded && jwtTokenAuth.Principal is not null)
            return AuthenticateResult.Success(new AuthenticationTicket(jwtTokenAuth.Principal, Scheme.Name));

        return AuthenticateResult.Fail("No valid token or api key");
    }

    private async Task HandleInitialize()
    {
        await _jwtTokenAuthHandler.InitializeAsync(Scheme, Context);
    }
}