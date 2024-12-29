using CoreBase.Consts.General;
using Microsoft.AspNetCore.Http;

namespace CoreBase.Extensions.Http;

public static class HttpRequestExtensions
{
    public static Boolean HasJsonContentType(this HttpRequest request)
        => request.ContentType is not null
        && request.ContentType.StartsWith(GeneralOperationConsts.ApplicationJsonKey, StringComparison.OrdinalIgnoreCase);


    public static String GetClientIpAddress(this HttpRequest request)
    {
        String? remoteIp = String.Empty;

        if (request.Headers.TryGetValue(GeneralOperationConsts.XForwardedForKey, out Microsoft.Extensions.Primitives.StringValues value))
            remoteIp = value.ToString();

        remoteIp ??= request.HttpContext.Connection.RemoteIpAddress?.ToString();

        if (String.IsNullOrWhiteSpace(remoteIp))
            throw new ArgumentNullException(nameof(remoteIp), "IP Address cannot be null or whitespace.");

        if (!System.Net.IPAddress.TryParse(remoteIp, out _))
            throw new FormatException("The provided IP Address is not in a valid format.");

        return remoteIp;
    }
}
