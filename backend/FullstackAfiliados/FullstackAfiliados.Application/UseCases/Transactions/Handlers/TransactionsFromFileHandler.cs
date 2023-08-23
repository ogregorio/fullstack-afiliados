using FullstackAfiliados.Application.UseCases.Base.Handlers;
using FullstackAfiliados.Application.UseCases.Transactions.Request;
using FullstackAfiliados.Application.UseCases.Transactions.Response;
using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Services.Interfaces;
using FullstackAfiliados.Infra.CrosCutting.Exceptions;
using FullstackAfiliados.Infra.CrosCutting.Helpers;

namespace FullstackAfiliados.Application.UseCases.Transactions.Handlers;

public class TransactionsFromFileHandler: IBaseHandler<TransactionsFromFileRequest, TransactionsFromFileResponse>
{
    private readonly ITransactionService _service;
    private readonly ITransactionTypeService _typeService;

    public TransactionsFromFileHandler(ITransactionService service, ITransactionTypeService typeService)
    {
        _service = service;
        _typeService = typeService;
    }

    public async Task<TransactionsFromFileResponse> Handle(TransactionsFromFileRequest request, CancellationToken cancellationToken)
    {
        if (request.File is null || request.File.Length == 0)
        {
            throw new BadRequestException("Invalid file");
        }

        using (var reader = new StreamReader(request.File.OpenReadStream()))
        {
            string content = await reader.ReadToEndAsync();
            List<Transaction> transactions = new SalesFile().Parse(content);
            foreach (var transaction in transactions)
            {
                var type = await _typeService.GetByRelativeTypeAsync(transaction.RelativeType);
                if (type is null)
                {
                    throw new BadRequestException("Invalid transaction type");
                }
                transaction.Type = type;
                await _service.CreateAsync(transaction);
            }
        }

        return new TransactionsFromFileResponse { Success = true };
    }
}