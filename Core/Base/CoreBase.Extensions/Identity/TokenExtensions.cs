using Microsoft.AspNetCore.Http;

namespace CoreBase.Extensions.Identity;

public static class TokenExtensions
{
    public static bool GetToken(this HttpContext httpContext, out string token)
    {
        token = string.Empty;

        string? authorizationHeader = httpContext.Request.Headers["Authorization"].FirstOrDefault();

        if (!string.IsNullOrWhiteSpace(authorizationHeader) && authorizationHeader.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
        {
            token = authorizationHeader["Bearer ".Length..].Trim();
            return true;
        }

        return false;
    }
}
