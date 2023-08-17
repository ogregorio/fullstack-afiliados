using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullstackAfiliados.Domain.Services.Implemented;

public class TransactionTypeService : BaseService<TransactionType>, ITransactionTypeService
{
    public TransactionTypeService(DbContext context) : base(context)
    {
    }

    public async Task<TransactionType?> GetByRelativeTypeAsync(int type)
    {
        IQueryable<TransactionType?> query = _dbSet.AsQueryable();
        return query.FirstOrDefault(x => x.Type == type);
    }
}