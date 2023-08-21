using FullstackAfiliados.Domain.Entities;

namespace FullstackAfiliados.Application.UseCases.Transactions.Response;

public class GetTransactionsPerSalesmanResponse
{
    public string Salesman { get; set; }
    public TransactionType Type { get; set; }
    public DateTime Date { get; set; }
    public string Product { get; set; }
    public Decimal Amount { get; set; }
}