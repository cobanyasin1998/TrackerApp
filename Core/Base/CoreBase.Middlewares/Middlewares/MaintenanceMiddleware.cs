using CoreBase.Exceptions.MiddlewareExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CoreBase.Middlewares.Middlewares;

public class MaintenanceMiddleware(RequestDelegate _next, IConfiguration config)
{
    private readonly bool _isInMaintenance = config.GetValue<bool>(MaintenanceModeKey);
    private const String MaintenanceModeKey = "MaintenanceMode";

    public async Task InvokeAsync(HttpContext context)
    {
        if (_isInMaintenance)
            throw new MaintenanceException("Service is under maintenance. Please try again later.");
        await _next(context);
    }
}
