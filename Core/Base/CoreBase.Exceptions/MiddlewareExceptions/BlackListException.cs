namespace CoreBase.Exceptions.MiddlewareExceptions;

public class BlackListException(string message) : Exception(message)
{
}
