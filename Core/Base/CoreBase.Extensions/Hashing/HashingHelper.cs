using System.Security.Cryptography;
using System.Text;

namespace CoreBase.Extensions.Hashing;

public static class HashingHelper
{
    public static (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password)
    {
        using HMACSHA512 hmac = new();
        return (hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),hmac.Key);
    }

    public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using HMACSHA512 hmac = new(passwordSalt);

        byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        return computedHash.SequenceEqual(passwordHash);
    }
}
