using FullstackAfiliados.Domain.Dto;
using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullstackAfiliados.Domain.Services.Implemented;

public class TransactionService : BaseService<Transaction>, ITransactionService
{
    public TransactionService(DbContext context) : base(context)
    {
    }

    public async Task<List<Transaction>> GetTransactionsBySalesman(string salesman)
    {
        IQueryable<Transaction> query = _dbSet.Where(t => t.Salesman == salesman);
        List<Transaction> transactions = await query.Include(x => x.Type).ToListAsync();
        return transactions;
    }

    public async Task<List<Salesman>> GetSalesman()
    {
        IQueryable<Transaction?> query = _dbSet.AsQueryable();
        var transactions = query
            .GroupBy(t => t.Salesman)
            .Select(group => new Salesman
            {
                Name = group.Key,
                TotalAmount = group.Sum(t => t.Type.Signal ? t.Amount : -t.Amount)
            })
            .ToListAsync();
        return await transactions;
    }
}