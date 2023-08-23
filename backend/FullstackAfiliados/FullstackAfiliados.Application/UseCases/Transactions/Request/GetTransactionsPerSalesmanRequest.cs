using FullstackAfiliados.Application.UseCases.Transactions.Response;
using MediatR;

namespace FullstackAfiliados.Application.UseCases.Transactions.Request;

public class GetTransactionsPerSalesmanRequest: IRequest<List<GetTransactionsPerSalesmanResponse>>
{
    public string Salesman { get; set; }
}