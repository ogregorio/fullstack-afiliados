using System.Security.Claims;
using FullstackAfiliados.Application.UseCases.Auth.Request;
using FullstackAfiliados.Application.UseCases.Auth.Response;
using FullstackAfiliados.Application.UseCases.Base.Handlers;
using FullstackAfiliados.Infra.CrosCutting.Exceptions;
using FullstackAfiliados.Infra.CrossCutting.Auth.Authorization;

namespace FullstackAfiliados.Application.UseCases.Auth.Handlers;

public class AuthenticateHandler : IBaseHandler<AuthenticateRequest, AuthenticateResponse>
{
    private readonly IJwtUtils _jwtUtils;

    public AuthenticateHandler(IJwtUtils jwtUtils)
    {
        _jwtUtils = jwtUtils;
    }

    public async Task<AuthenticateResponse> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
    {
        var username = Environment.GetEnvironmentVariable("SYSTEM_USERNAME");
        var password = Environment.GetEnvironmentVariable("SYSTEM_PASSWORD");

        if (request.Username != username || request.Password != password)
            throw new NotFoundException("Username or password is incorrect");

        var claimsList = new Claim[]
        {
            new(ClaimTypes.Name, username),
        };

        var jwtToken = _jwtUtils.GenerateJwtToken(claimsList);

        return new AuthenticateResponse(username, jwtToken);
    }
}