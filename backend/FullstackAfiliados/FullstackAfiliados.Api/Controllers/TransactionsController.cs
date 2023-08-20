using FullstackAfiliados.Api.Controllers.Base;
using FullstackAfiliados.Application.UseCases.Transactions.Request;
using FullstackAfiliados.Application.UseCases.Transactions.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullstackAfiliados.Api.Controllers;

[Route("transactions")]
public class TransactionsController: MainController
{
    private readonly IMediator _mediator;

    public TransactionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Validate template
    /// </summary>
    /// <returns></returns>
    [Consumes("multipart/form-data")]
    [HttpPost("file")]
    public async Task<ActionResult<TransactionsFromFileResponse>> PostAsync(IFormFile file)
    {
        var result = await _mediator.Send(new TransactionsFromFileRequest { File = file });
        return Ok(result);
    }
}