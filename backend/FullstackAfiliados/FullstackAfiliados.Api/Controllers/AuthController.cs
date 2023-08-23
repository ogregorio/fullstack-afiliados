using FullstackAfiliados.Api.Controllers.Base;
using FullstackAfiliados.Application.UseCases.Auth.Request;
using FullstackAfiliados.Application.UseCases.Auth.Response;
using FullstackAfiliados.Infra.CrossCutting.Auth.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullstackAfiliados.Api.Controllers;

[Route("auth")]
public class AuthController: MainController
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost, Public]
    [ProducesResponseType(typeof(AuthenticateResponse), 200)]
    public async Task<OkObjectResult> Authenticate(AuthenticateRequest model)
    {
        var response = await _mediator.Send(model);
        return Ok(response);
    }
}