namespace CoreBase.Interfaces.DataProtectInterfaces;

public interface IDataProtect
{
    String Encrypt(long originalId);
    long Decrypt(String encryptedText);
}
