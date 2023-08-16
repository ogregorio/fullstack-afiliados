using FullstackAfiliados.Domain.Entities.Base;

namespace FullstackAfiliados.Domain.Entities;

public class Transaction: Entity
{
    public virtual TransactionType Type { get; set; }
    public virtual Guid TypeId { get; set; }
    public DateTime Date { get; set; }
    public string Product { get; set; }
    public Decimal Amount { get; set; }
    public string Salesman { get; set; }
}