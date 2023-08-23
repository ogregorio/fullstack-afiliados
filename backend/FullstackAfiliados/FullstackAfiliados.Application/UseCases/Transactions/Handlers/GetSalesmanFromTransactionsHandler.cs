using AutoMapper;
using FullstackAfiliados.Application.UseCases.Base.Handlers;
using FullstackAfiliados.Application.UseCases.Transactions.Request;
using FullstackAfiliados.Application.UseCases.Transactions.Response;
using FullstackAfiliados.Domain.Services.Interfaces;

namespace FullstackAfiliados.Application.UseCases.Transactions.Handlers;

public class GetSalesmanFromTransactionsHandler: IBaseHandler<GetSalesmanFromTransactionsRequest, List<GetSalesmanFromTransactionsResponse>>
{
    private readonly ITransactionService _service;
    private readonly IMapper _mapper;

    public GetSalesmanFromTransactionsHandler(ITransactionService transactionService, IMapper mapper)
    {
        _service = transactionService;
        _mapper = mapper;
    }

    public async Task<List<GetSalesmanFromTransactionsResponse>> Handle(GetSalesmanFromTransactionsRequest request, CancellationToken cancellationToken)
    {
        var result = await _service.GetSalesman();
        return _mapper.Map<List<GetSalesmanFromTransactionsResponse>>(result);
    }
}