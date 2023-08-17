using MediatR;
using Microsoft.AspNetCore.Http;
using FullstackAfiliados.Application.UseCases.Transactions.Response;

namespace FullstackAfiliados.Application.UseCases.Transactions.Request;

public class TransactionsFromFileRequest : IRequest<TransactionsFromFileResponse>
{
    public IFormFile File { get; set; }
}