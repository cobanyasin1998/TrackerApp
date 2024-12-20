using CoreBase.Consts.General;
using Microsoft.AspNetCore.Http;

namespace CoreBase.Extensions.Http;

public static class HttpRequestExtensions
{
    public static bool HasJsonContentType(this HttpRequest request)
        => request.ContentType is not null
        && request.ContentType.StartsWith(GeneralOperationConsts.ApplicationJsonKey, StringComparison.OrdinalIgnoreCase);


    public static string? GetClientIpAddress(this HttpRequest request) 
        => request.Headers.ContainsKey(GeneralOperationConsts.XForwardedForKey)
        ? request.Headers[GeneralOperationConsts.XForwardedForKey]
        : request.HttpContext.Connection.RemoteIpAddress.ToString();
}
