using CoreBase.Consts.General;
using Microsoft.AspNetCore.Http;

namespace CoreBase.Middlewares.Middlewares;

public class CorrelationIdMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        if (!context.Request.Headers.ContainsKey(GeneralOperationConsts.CorrelationIdHeader))
            context.Request.Headers[GeneralOperationConsts.CorrelationIdHeader] = Guid.NewGuid().ToString();
        context.Response.Headers[GeneralOperationConsts.CorrelationIdHeader] = context.Request.Headers[GeneralOperationConsts.CorrelationIdHeader];
        await _next(context);
    }
}
