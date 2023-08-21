using Microsoft.AspNetCore.Authentication;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Options;

public class AuthOptions : AuthenticationSchemeOptions
{
    public string? TokenHeader { get; set; } // Header that contains the JWT token
    public string? ApiKey { get; set; } // Header that contains the Api key
}