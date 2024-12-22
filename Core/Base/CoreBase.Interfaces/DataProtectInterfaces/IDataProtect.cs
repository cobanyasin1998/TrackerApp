namespace CoreBase.Interfaces.DataProtectInterfaces;

public interface IDataProtect
{
    String Encrypt(Int64 originalId);
    Int64 Decrypt(String encryptedText);
}
