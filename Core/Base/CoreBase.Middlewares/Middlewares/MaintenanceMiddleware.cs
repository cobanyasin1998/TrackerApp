using CoreBase.Consts.General;
using CoreBase.Exceptions.MiddlewareExceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CoreBase.Middlewares.Middlewares;

public class MaintenanceMiddleware(RequestDelegate _next, IConfiguration _config)
{
    private readonly Boolean isInMaintenance = _config.GetValue<bool>(GeneralOperationConsts.MaintenanceModeKey);

    public async Task InvokeAsync(HttpContext context)
    {
        if (isInMaintenance)
            throw new MaintenanceException();
        await _next(context);
    }
}
