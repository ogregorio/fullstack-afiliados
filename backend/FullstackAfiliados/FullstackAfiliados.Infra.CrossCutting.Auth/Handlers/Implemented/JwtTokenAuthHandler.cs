using System.Security.Claims;
using FullstackAfiliados.Infra.CrossCutting.Auth.Authorization;
using FullstackAfiliados.Infra.CrossCutting.Auth.Handlers.Interfaces;
using FullstackAfiliados.Infra.CrossCutting.Auth.Options;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Handlers.Implemented;

public class JwtTokenAuthHandler : IJwtTokenAuthHandler
{
    private readonly IJwtUtils _jwtUtils;
    private HttpContext _httpContext;
    private IOptionsMonitor<AuthOptions> _options;
    private AuthenticationScheme _scheme;

    public JwtTokenAuthHandler(
        IOptionsMonitor<AuthOptions> options
    )
    {
        _options = options;
    }

    public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
    {
        _scheme = scheme;
        _httpContext = context;
        return Task.CompletedTask;
    }

    public async Task<AuthenticateResult> AuthenticateAsync()
    {
        var options = _options.Get(_scheme.Name);
        var authHeader = _httpContext.Request.Headers[options.TokenHeader].FirstOrDefault();

        if (authHeader is null)
            return AuthenticateResult.NoResult();

        var authHeaderValues = authHeader.Split(' ');
        if (authHeaderValues.Length < 2)
            return AuthenticateResult.NoResult();

        var token = authHeaderValues[1];
        if (string.IsNullOrEmpty(token))
            return AuthenticateResult.NoResult();

        var claimsList = _jwtUtils.ValidateJwtToken(token);

        var identity = new ClaimsIdentity(claimsList, _scheme.Name);
        var principal = new ClaimsPrincipal(identity);

        return AuthenticateResult.Success(new AuthenticationTicket(principal, _scheme.Name));
    }

    public Task ChallengeAsync(AuthenticationProperties properties)
    {
        throw new NotImplementedException();
    }

    public Task ForbidAsync(AuthenticationProperties properties)
    {
        throw new NotImplementedException();
    }
}