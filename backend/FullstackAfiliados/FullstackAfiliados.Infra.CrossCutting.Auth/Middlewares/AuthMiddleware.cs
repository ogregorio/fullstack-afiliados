using System.Security.Claims;
using FullstackAfiliados.Infra.CrossCutting.Auth.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Middlewares;

public static class AuthMiddleware
{
    public static IServiceCollection AddAuthUser(this IServiceCollection services)
    {
        services.AddScoped<IUser, User>(x => new User());
        return services;
    }

    public static IApplicationBuilder UseAuthUser(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            if (!context.User.Identity.IsAuthenticated)
            {
                await next.Invoke();
                return;
            }

            var services = context.RequestServices;
            var user = services.GetRequiredService<IUser>();
            var claimsList = context.User.Claims.ToList();

            user.Username = claimsList.FirstOrDefault(x => x.Type.Equals("unique_name"))?.Value;

            await next.Invoke();
        });

        return app;
    }
}