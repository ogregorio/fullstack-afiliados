using FullstackAfiliados.Domain.Dto;
using FullstackAfiliados.Domain.Entities;

namespace FullstackAfiliados.Domain.Services.Interfaces;

public interface ITransactionService: IBaseService<Transaction>
{
    Task<List<Transaction>> GetTransactionsBySalesman(string salesman);
    Task<List<Salesman>> GetSalesman();
}