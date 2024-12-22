using CoreBase.Consts.General;
using CoreBase.Exceptions.MiddlewareExceptions;
using Microsoft.AspNetCore.Http;

namespace CoreBase.Middlewares.Middlewares;

public class BotDetectionMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        string userAgent = context.Request.Headers[GeneralOperationConsts.UserAgent].ToString();
        if (IsBot(userAgent))
            throw new BotDetectedException();
        await _next(context);
    }

    private static bool IsBot(string userAgent)
    {
        string[] botIndicators = { "bot", "spider", "crawler", "curl", "wget" };
        return botIndicators.Any(userAgent.ToLower().Contains);
    }
}
