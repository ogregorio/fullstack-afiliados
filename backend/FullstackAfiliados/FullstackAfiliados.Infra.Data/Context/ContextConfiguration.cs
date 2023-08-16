using FullstackAfiliados.Infra.Data.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FullstackAfiliados.Infra.Data.Configurations;

public static class ContextConfiguration
{
    public static void UpdateDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices
            .GetService<IServiceScopeFactory>()?
            .CreateScope();

        using var context = serviceScope?.ServiceProvider.GetService<DataContext>();
        context?.Database.Migrate();
    }
}