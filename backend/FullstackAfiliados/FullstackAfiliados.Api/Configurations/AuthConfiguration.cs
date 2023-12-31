using FullstackAfiliados.Infra.CrossCutting.Auth.Handlers;
using FullstackAfiliados.Infra.CrossCutting.Auth.Middlewares;
using FullstackAfiliados.Infra.CrossCutting.Auth.Options;

namespace FullstackAfiliados.Api.Configurations;

public static class AuthConfiguration
{
    public static IServiceCollection AddAuthConfiguration(this IServiceCollection services)
    {
        services.AddAuthentication("DefaultAuth")
            .AddScheme<AuthOptions, AuthHandler>(
                "DefaultAuth", options =>
                {
                    options.TokenHeader = "Authorization";
                }
            );
        return services;
    }
}