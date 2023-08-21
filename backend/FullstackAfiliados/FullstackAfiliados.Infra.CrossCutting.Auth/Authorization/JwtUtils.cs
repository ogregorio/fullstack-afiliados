using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Authorization;

public class JwtUtils : IJwtUtils
{
    private readonly string? _secret = Environment.GetEnvironmentVariable("JWT_SECRET");

    public string GenerateJwtToken(Claim[]? claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secret!);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public List<Claim>? ValidateJwtToken(string? token)
    {
        if (token is null)
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secret!);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;

            return jwtToken.Claims.ToList();
        }
        catch (SecurityTokenExpiredException e)
        {
            throw new UnauthorizedAccessException("Expired token");
        }
        catch (SecurityTokenMalformedException e)
        {
            throw new UnauthorizedAccessException("Malformed token");
        }
        catch (SecurityTokenException e)
        {
            throw new UnauthorizedAccessException("Unauthorized");
        }
    }
}