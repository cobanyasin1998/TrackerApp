namespace CoreBase.Exceptions.MiddlewareExceptions;

public class InvalidRequestException : Exception
{
    public InvalidRequestException() : base("Invalid request format.")
    {
    }
}
