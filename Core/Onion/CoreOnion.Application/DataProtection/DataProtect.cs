using CoreBase.Consts.DataProtection;
using CoreBase.Exceptions.CustomExceptions;
using CoreBase.Interfaces.DataProtectInterfaces;
using Microsoft.AspNetCore.DataProtection;

namespace CoreOnion.Application.DataProtection;

public class DataProtect(IDataProtector _dataProtector) : IDataProtect
{
    public long Decrypt(String encryptedText)
    {
        if (string.IsNullOrWhiteSpace(encryptedText))
            ThrowInvalidKeyException(encryptedText);

        String key = _dataProtector.Unprotect(encryptedText);

        if (!long.TryParse(key, out long result))
            ThrowInvalidKeyException(encryptedText);

        return result;
    }

    public String Encrypt(long originalId)
        => _dataProtector.Protect(originalId.ToString());

    private static void ThrowInvalidKeyException(string encryptedText)
        => throw new DataProtectKeyException(DataProtectionConsts.NoValidKey, encryptedText);
}
