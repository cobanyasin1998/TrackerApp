using CoreBase.Identity.Entities.Base;

namespace CoreBase.Identity.IdentityInterfaces;

public interface ITokenService
{
    string GenerateAccessToken(UserEntity user);
    string GenerateRefreshToken();
}
