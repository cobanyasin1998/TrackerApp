namespace CoreBase.Exceptions.CustomExceptions;

public class DataProtectKeyException(String message, String key) : Exception(message)
{
    public String Key { get; } = key;
}
