using AutoMapper;
using FullstackAfiliados.Application.UseCases.Transactions.Response;
using FullstackAfiliados.Domain.Entities;

namespace FullstackAfiliados.Application.Helpers.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Transaction, GetTransactionsPerSalesmanResponse>();
    }
}