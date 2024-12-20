using CoreBase.Exceptions.MiddlewareExceptions;
using CoreBase.Extensions.Http;
using Microsoft.AspNetCore.Http;

namespace CoreBase.Middlewares.Middlewares;

public class AdvancedRequestValidationMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.HasJsonContentType())
            throw new InvalidRequestException();

        await _next(context);
    }
}
