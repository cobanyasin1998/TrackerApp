using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CoreBase.Extensions.Identity;

public static class ClaimsExtensions
{
    public static void AddEmail(this ICollection<Claim> claims, String email) =>
    claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));

    public static void AddName(this ICollection<Claim> claims, String name)
        => claims.Add(new Claim(ClaimTypes.Name, name));

    public static void AddNameIdentifier(this ICollection<Claim> claims, String nameIdentifier) =>
        claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));

    public static void AddRoles(this ICollection<Claim> claims, String[] roles) =>
        roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));

    public static String? GetClaimValue(this HttpContext httpContext, String claimType)
        => httpContext?.User?.Claims?.FirstOrDefault(c => c.Type == claimType)?.Value;

    public static int GetUserId(this HttpContext httpContext)
        => Convert.ToInt32(httpContext.GetClaimValue(ClaimTypes.NameIdentifier));

    public static String? GetUserName(this HttpContext httpContext)
        => httpContext.GetClaimValue(ClaimTypes.Name);
}
