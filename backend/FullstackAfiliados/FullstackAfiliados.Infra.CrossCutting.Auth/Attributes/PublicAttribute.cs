using Microsoft.AspNetCore.Mvc.Filters;

namespace FullstackAfiliados.Infra.CrossCutting.Auth.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class PublicAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
    }
}