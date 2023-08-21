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
    /// Validate and process file from template
    /// </summary>
    /// <returns></returns>
    [Consumes("multipart/form-data")]
    [HttpPost("file")]
    public async Task<ActionResult<TransactionsFromFileResponse>> PostAsync(IFormFile file)
    {
        var result = await _mediator.Send(new TransactionsFromFileRequest { File = file });
        return Ok(result);
    }

    /// <summary>
    /// Get transactions per salesman
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<GetTransactionsPerSalesmanResponse>> GetAsync([FromQuery] GetTransactionsPerSalesmanRequest request)
    {
        var result = await _mediator.Send(request);
        return Ok(result);
    }

    /// <summary>
    /// Get salesman from transactions
    /// </summary>
    /// <returns></returns>
    [HttpGet("salesman")]
    public async Task<ActionResult<GetSalesmanFromTransactionsResponse>> GetAsync()
    {
        var result = await _mediator.Send(new GetSalesmanFromTransactionsRequest {});
        return Ok(result);
    }
}