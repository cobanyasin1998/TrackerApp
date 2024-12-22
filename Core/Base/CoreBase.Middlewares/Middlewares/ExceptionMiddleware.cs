using CoreBase.Consts.General;
using CoreBase.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace CoreBase.Middlewares.Middlewares;

public class ExceptionMiddleware(RequestDelegate _next, ILogger<ExceptionMiddleware> _logger)
{
    private readonly HttpExceptionHandler _httpExceptionHandler = new();

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (System.Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, System.Exception exception)
    {
        context.Response.ContentType = GeneralOperationConsts.ApplicationJsonKey;
        await _httpExceptionHandler.HandleExceptionAsync(exception, context);
    }
}
