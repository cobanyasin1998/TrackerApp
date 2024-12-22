namespace CoreBase.Exceptions.MiddlewareExceptions;


public class MaintenanceException : Exception
{
    public MaintenanceException() : base("Service is under maintenance. Please try again later.")
    {
    }
}
