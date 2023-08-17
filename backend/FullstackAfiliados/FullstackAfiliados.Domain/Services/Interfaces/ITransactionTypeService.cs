using FullstackAfiliados.Domain.Entities;

namespace FullstackAfiliados.Domain.Services.Interfaces;

public interface ITransactionTypeService: IBaseService<TransactionType>
{
    Task<TransactionType?> GetByRelativeTypeAsync(int type);
}