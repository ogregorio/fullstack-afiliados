using AutoMapper;
using FullstackAfiliados.Application.UseCases.Base.Handlers;
using FullstackAfiliados.Application.UseCases.Transactions.Request;
using FullstackAfiliados.Application.UseCases.Transactions.Response;
using FullstackAfiliados.Domain.Services.Interfaces;
using FullstackAfiliados.Infra.CrosCutting.Exceptions;

namespace FullstackAfiliados.Application.UseCases.Transactions.Handlers;

public class GetTransactionsPerSalesmanHandler: IBaseHandler<GetTransactionsPerSalesmanRequest, List<GetTransactionsPerSalesmanResponse>>
{
    private readonly ITransactionService _service;
    private readonly IMapper _mapper;

    public GetTransactionsPerSalesmanHandler(ITransactionService transactionService, IMapper mapper)
    {
        _service = transactionService;
        _mapper = mapper;
    }

    public async Task<List<GetTransactionsPerSalesmanResponse>> Handle(GetTransactionsPerSalesmanRequest request, CancellationToken cancellationToken)
    {
        var transactions = await _service.GetTransactionsBySalesman(request.Salesman);
        if (transactions.Count == 0)
        {
            throw new NotFoundException("Salesman name are incorrect or don't has any transactions");
        }

        return _mapper.Map<List<GetTransactionsPerSalesmanResponse>>(transactions);
    }
}