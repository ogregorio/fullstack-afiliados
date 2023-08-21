using System.Security.Claims;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Authorization;

public interface IJwtUtils
{
    public string GenerateJwtToken(Claim[]? claims);
    public List<Claim>? ValidateJwtToken(string token);
}