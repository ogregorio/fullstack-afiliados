using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullstackAfiliados.Domain.Services.Implemented;

public class TransactionService : BaseService<Transaction>, ITransactionService
{
    public TransactionService(DbContext context) : base(context)
    {
    }
}