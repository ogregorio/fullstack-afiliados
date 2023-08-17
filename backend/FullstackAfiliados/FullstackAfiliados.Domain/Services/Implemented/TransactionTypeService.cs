using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FullstackAfiliados.Domain.Services.Implemented;

public class TransactionTypeService : BaseService<TransactionType>, ITransactionTypeService
{
    public TransactionTypeService(DbContext context) : base(context)
    {
    }
}