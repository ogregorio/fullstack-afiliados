using FullstackAfiliados.Domain.Entities.Base;

namespace FullstackAfiliados.Domain.Entities;

public class TransactionType: Entity
{
    public int Type { get; set; }
    public string Description { get; set; }
    public string Origin { get; set; }
    public bool Signal { get; set; }
}