namespace CoreBase.Exceptions.MiddlewareExceptions;


public class MaxRequestSizeException(string message) : Exception(message)
{
}
