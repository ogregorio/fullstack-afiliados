using System.ComponentModel.DataAnnotations;
using FullstackAfiliados.Application.UseCases.Auth.Response;
using MediatR;

namespace FullstackAfiliados.Application.UseCases.Auth.Request;

public class AuthenticateRequest : IRequest<AuthenticateResponse>
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}