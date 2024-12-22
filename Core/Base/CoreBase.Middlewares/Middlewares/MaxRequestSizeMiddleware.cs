using CoreBase.Consts.General;
using CoreBase.Exceptions.MiddlewareExceptions;
using CoreBase.Extensions.Size;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CoreBase.Middlewares.Middlewares;

public class MaxRequestSizeMiddleware(RequestDelegate _next, IConfiguration _config)
{
    private readonly Int32 maxRequestSizeInBytes = _config.GetValue<int>(GeneralOperationConsts.MaxRequestSize).ToBytes();

    public async Task InvokeAsync(HttpContext context)
    {
        if (context.Request.ContentLength.HasValue && context.Request.ContentLength.Value > maxRequestSizeInBytes)
            throw new MaxRequestSizeException($"Request body exceeds maximum allowed size of {maxRequestSizeInBytes / (1024 * 1024)} MB.");
        await _next(context);
    }
}
