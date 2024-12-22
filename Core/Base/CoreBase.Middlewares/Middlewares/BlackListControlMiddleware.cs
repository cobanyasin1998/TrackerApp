using CoreBase.Exceptions.MiddlewareExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using CoreBase.Extensions.Http;
using CoreBase.Consts.Middleware;

namespace CoreBase.Middlewares.Middlewares;

public class BlackListControlMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private readonly RequestDelegate _next = next;
    private readonly HashSet<String> _blacklist = configuration.GetSection(BlackListConsts.BlackList).Get<HashSet<String>>() ?? [];

    public async Task InvokeAsync(HttpContext context)
    {
        String remoteIp = context.Request.GetClientIpAddress();
        if (_blacklist.Contains(remoteIp))
            throw new BlackListException(BlackListConsts.AccessDeniedBlackListed);
        await _next(context);
    }
}
