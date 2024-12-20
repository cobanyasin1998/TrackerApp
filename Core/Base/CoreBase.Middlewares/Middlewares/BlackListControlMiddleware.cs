using CoreBase.Exceptions.MiddlewareExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CoreBase.Middlewares.Middlewares;

public class BlackListControlMiddleware(RequestDelegate next, IConfiguration configuration)
{
    private readonly RequestDelegate _next = next;
    private readonly HashSet<string> _blacklist = configuration.GetSection("Blacklist").Get<HashSet<string>>() ?? [];

    public async Task InvokeAsync(HttpContext context)
    {
        string? remoteIp = context.Connection.RemoteIpAddress?.ToString();

        if (_blacklist.Contains(remoteIp))
            throw new BlackListException("Access Denied: Your is blacklisted.");

        await _next(context);
    }
}
