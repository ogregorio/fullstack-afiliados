using Microsoft.AspNetCore.Authentication;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Options;

public class AuthOptions : AuthenticationSchemeOptions
{
    public string? TokenHeader { get; set; }
}