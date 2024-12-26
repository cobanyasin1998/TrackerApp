using CoreBase.Consts.DataProtection;
using CoreBase.Exceptions.CustomExceptions;
using CoreBase.Interfaces.DataProtectInterfaces;
using Microsoft.AspNetCore.DataProtection;

namespace CoreOnion.Application.DataProtection;

public class DataProtect(IDataProtector _dataProtector) : IDataProtect
{
    public Int64 Decrypt(String encryptedText)
    {
        if (String.IsNullOrWhiteSpace(encryptedText))
            ThrowInvalidKeyException(encryptedText);

        String key = _dataProtector.Unprotect(encryptedText);

        if (!Int64.TryParse(key, out Int64 result))
            ThrowInvalidKeyException(encryptedText);

        return result;
    }

    public String Encrypt(Int64 originalId)
        => _dataProtector.Protect(originalId.ToString());

    private static void ThrowInvalidKeyException(String encryptedText)
        => throw new DataProtectKeyException(DataProtectionConsts.NoValidKey, encryptedText);
}
