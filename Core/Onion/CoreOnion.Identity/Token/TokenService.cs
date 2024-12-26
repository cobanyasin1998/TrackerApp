﻿using CoreBase.Extensions.Identity;
using CoreBase.Identity.Entities.Base;
using CoreBase.Identity.IdentityInterfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CoreOnion.Identity.Token;

public class TokenService(IConfiguration _configuration) : ITokenService
{
    public String GenerateAccessToken(UserEntity user)
    {
        List<Claim> claims = GetClaims(user);

        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["JwtSettings:SecurityKey"]!));
        SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new(
            issuer: _configuration["JwtSettings:Issuer"],
            audience: _configuration["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private static List<Claim> GetClaims(UserEntity user)
    {
        List<Claim> claims = [];
       // claims.AddEmail(user.Email);
       // claims.AddName(user.Username);
        claims.AddNameIdentifier(user.Id.ToString());
        //claims.Add(new Claim("OrganizationId", user.OrganizationEntityId.ToString()));
        return claims;
    }

    public String GenerateRefreshToken()
        => Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
}
