namespace CoreBase.Exceptions.MiddlewareExceptions;

public class BlackListException : Exception
{
    public BlackListException(string message) : base(message)
    {
    }
}
