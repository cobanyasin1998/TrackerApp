using CoreBase.Identity.Entities.Base;

namespace CoreBase.Identity.Entities.Identity;

public class RefreshTokenEntity : UserEntity
{
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public bool IsExpired => DateTime.UtcNow >= Expires;
    public bool IsActive => !IsRevoked && !IsExpired;
    public DateTime Created { get; set; }
    public string CreatedByIp { get; set; }
    public DateTime? Revoked { get; set; }
    public string? RevokedByIp { get; set; }
    public string? ReplacedByToken { get; set; }
    public bool IsRevoked => Revoked != null;
    public bool IsReplaced => ReplacedByToken != null;
    public bool IsInvalidated => IsRevoked || IsReplaced;
}
