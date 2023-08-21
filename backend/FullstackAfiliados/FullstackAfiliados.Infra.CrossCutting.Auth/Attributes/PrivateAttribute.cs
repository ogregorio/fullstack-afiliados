using FullstackAfiliados.Infra.CrosCutting.Exceptions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class PrivateAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if (!context.HttpContext.User.Identity.IsAuthenticated)
            throw new UnauthorizedException("Unauthorized");

        var user = context.HttpContext.User;

        if (user is not null)
            return;

        throw new ForbiddenException("Unauthorized");
    }
}