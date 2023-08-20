using Microsoft.AspNetCore.CookiePolicy;

namespace FullstackAfiliados.Api.Configurations;

public static class CorsConfiguration
{
    public static IServiceCollection CorsConfig(this IServiceCollection services)
    {
        services.AddCors();
        services.Configure<CookiePolicyOptions>(options =>
        {
            options.HttpOnly = HttpOnlyPolicy.Always;
            options.Secure = CookieSecurePolicy.Always;
        });
        return services;
    }
}