using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Services.Interfaces;
using Newtonsoft.Json;

namespace FullstackAfiliados.Api.Bootstrap;

public static class TypesBootstrap
{
    private static ITransactionTypeService? _service;
    const string FilePath = "default_types.json";

    public static async Task<IApplicationBuilder> UseTypesBootstrap(this IApplicationBuilder app)
    {
        var serviceScopeFactory = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>();
        using var scope = serviceScopeFactory.CreateScope();
        var serviceProvider = scope.ServiceProvider;
        _service = serviceProvider.GetRequiredService<ITransactionTypeService>();
        string content = File.ReadAllText(FilePath);
        List<TransactionType>? transactions = JsonConvert.DeserializeObject<List<TransactionType>>(content);
        if (transactions is not null)
        {
            foreach (var transaction in transactions)
            {
                await _service.CreateIfNotExists(transaction);
            }
        }

        return app;
    }
}