using Microsoft.OpenApi.Models;

namespace FullstackAfiliados.Api.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection GenDocumentation(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Fullstack.Afiliados.Api", Version = "v1" });
        });
        return services;
    }
}