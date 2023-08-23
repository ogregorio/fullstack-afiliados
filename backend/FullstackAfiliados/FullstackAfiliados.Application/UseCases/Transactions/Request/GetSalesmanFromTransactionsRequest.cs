using FullstackAfiliados.Application.UseCases.Transactions.Response;
using MediatR;

namespace FullstackAfiliados.Application.UseCases.Transactions.Request;

public class GetSalesmanFromTransactionsRequest: IRequest<List<GetSalesmanFromTransactionsResponse>>
{
}