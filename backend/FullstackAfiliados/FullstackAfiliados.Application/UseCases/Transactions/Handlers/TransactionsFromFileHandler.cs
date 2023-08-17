using FullstackAfiliados.Application.UseCases.Base.Handlers;
using FullstackAfiliados.Application.UseCases.Transactions.Request;
using FullstackAfiliados.Application.UseCases.Transactions.Response;
using FullstackAfiliados.Domain.Entities;
using FullstackAfiliados.Domain.Services.Interfaces;
using FullstackAfiliados.Infra.CrosCutting.Helpers;

namespace FullstackAfiliados.Application.UseCases.Transactions.Handlers;

public class TransactionsFromFileHandler: IBaseHandler<TransactionsFromFileRequest, TransactionsFromFileResponse>
{
    private readonly ITransactionService _service;

    public TransactionsFromFileHandler(ITransactionService service)
    {
        _service = service;
    }

    public async Task<TransactionsFromFileResponse> Handle(TransactionsFromFileRequest request, CancellationToken cancellationToken)
    {
        if (request.File is null || request.File.Length == 0)
        {
            throw new Exception("Invalid file");
        }

        using (var reader = new StreamReader(request.File.OpenReadStream()))
        {
            string content = await reader.ReadToEndAsync();
            List<Transaction> transactions = new SalesFile().Parse(content);
            foreach (var transaction in transactions)
            {
                await _service.CreateAsync(transaction);
            }
        }

        return new TransactionsFromFileResponse { Success = true };
    }
}