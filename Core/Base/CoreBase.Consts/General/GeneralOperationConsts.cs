namespace CoreBase.Consts.General;

public static class GeneralOperationConsts
{
    private static readonly String Operation = "Operation";
    public static readonly String OperationSuccessfull = $"{Operation} successfull";
    public static readonly String OperationFailed = $"{Operation} failed";
    public static readonly String ApplicationJsonKey = "application/json";
    public static readonly String XForwardedForKey = "X-Forwarded-For";
    public static readonly String UserAgent = "User-Agent";
    public static readonly String CorrelationIdHeader = "X-Correlation-ID";
    public static readonly String MaintenanceModeKey = "MaintenanceMode";
    public static readonly String MaxRequestSize = "MaxRequestSize";
    public static readonly String? AnErrorOccurred = "An Error Occurred";

    public static String GetRequestBodySizeExceededMessage(long maxRequestSizeInBytes) 
        => $"Request body exceeds maximum allowed size of {maxRequestSizeInBytes / (1024 * 1024)} MB.";
}
