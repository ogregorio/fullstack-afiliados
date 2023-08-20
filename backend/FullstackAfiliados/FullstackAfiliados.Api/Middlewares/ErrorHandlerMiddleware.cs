using System.Net;
using System.Text.Json;
using FullstackAfiliados.Infra.CrosCutting.Exceptions;
using MediatR;

namespace FullstackAfiliados.Api.Middlewares;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IMediator mediator)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            Console.WriteLine(error.ToString());

            switch (error)
            {
                case BadRequestException e:
                    // custom application error
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case NotFoundException e:
                    // not found error
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case ForbiddenException e:
                    response.StatusCode = (int)HttpStatusCode.Forbidden;
                    break;
                case TooManyRequestsException e:
                    response.StatusCode = (int)HttpStatusCode.TooManyRequests;
                    break;
                case UnauthorizedException e:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case ServiceUnavailableException e:
                    response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                    break;
                case MethodNotAllowedException e:
                    response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                    break;
                default:
                    // unhandled error
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            var result = JsonSerializer.Serialize(new { message = error?.Message });
            await response.WriteAsync(result);
        }
    }
}