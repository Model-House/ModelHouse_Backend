using backend.Register.Domain.Models;
using backend.Security.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace backend.Security.Authorization.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizeAttribute : Attribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        // If action is decorated with [AllowAnonymous] attribute
        
        var allowAnonymous = context.ActionDescriptor
            .EndpointMetadata
            .OfType<AllowAnonymousAttribute>().Any();
        
        // Then skip authorization process

        if (allowAnonymous)
            return;
        
        // Authorization process
        var user = context.HttpContext.Items["User"];
        if (user == null)
            context.Result = new JsonResult(new { message = "Unauthorized 1" })
                { StatusCode = StatusCodes.Status401Unauthorized };
    }
}