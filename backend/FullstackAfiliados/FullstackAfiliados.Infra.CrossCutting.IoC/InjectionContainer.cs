using FullstackAfiliados.Domain.Services.Implemented;
using FullstackAfiliados.Domain.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FullstackAfiliados.Infra.CrossCutting.IoC;

public static class InjectionContainer
{
    public static IServiceCollection InjectDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        {
            // Register Services
            services.AddScoped<ITransactionService, TransactionService>();
        }
        return services;
    }
}