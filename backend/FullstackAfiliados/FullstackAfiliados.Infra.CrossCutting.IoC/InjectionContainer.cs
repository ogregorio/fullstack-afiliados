using FullstackAfiliados.Application.UseCases.Transactions.Handlers;
using FullstackAfiliados.Application.UseCases.Transactions.Request;
using FullstackAfiliados.Application.UseCases.Transactions.Response;
using FullstackAfiliados.Domain.Services.Implemented;
using FullstackAfiliados.Domain.Services.Interfaces;
using MediatR;
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
            services.AddScoped<ITransactionTypeService, TransactionTypeService>();
        }
        {
            // Register Use Cases
            services.AddScoped<IRequestHandler<TransactionsFromFileRequest, TransactionsFromFileResponse>, TransactionsFromFileHandler>();
            services.AddScoped<IRequestHandler<GetTransactionsPerSalesmanRequest, List<GetTransactionsPerSalesmanResponse>>, GetTransactionsPerSalesmanHandler>();
            services.AddScoped<IRequestHandler<GetSalesmanFromTransactionsRequest, List<GetSalesmanFromTransactionsResponse>>, GetSalesmanFromTransactionsHandler>();
        }
        return services;
    }
}