namespace CoreBase.Consts.General;

public static class GeneralOperationConsts
{
    private const string Operation = "Operation";
    public const string OperationSuccessfull = $"{Operation} successfull";
    public const string OperationFailed = $"{Operation} failed";

    public const string ApplicationJsonKey = "application/json";
    public const string XForwardedForKey = "X-Forwarded-For";
    public const string UserAgent = "User-Agent";
    public const string CorrelationIdHeader = "X-Correlation-ID";
    public const String MaintenanceModeKey = "MaintenanceMode";

    public const string MaxRequestSize = "MaxRequestSize";

    public static string GetRequestBodySizeExceededMessage(long maxRequestSizeInBytes)
    {
        return $"Request body exceeds maximum allowed size of {maxRequestSizeInBytes / (1024 * 1024)} MB.";
    }

    //// İşlem ile ilgili sabitler
    //public const string CreateOperation = "Create";
    //public const string UpdateOperation = "Update";
    //public const string DeleteOperation = "Delete";
    //public const string RetrieveOperation = "Retrieve";




    //// Genel hata mesajları
    //public const string InvalidInputErrorMessage = "Geçersiz giriş. Lütfen tekrar kontrol edin.";
    //public const string NotFoundErrorMessage = "Veri bulunamadı.";
    //public const string OperationFailedErrorMessage = "İşlem başarısız oldu, lütfen tekrar deneyin.";

    //// Genel sınır değerler
    //public const int MaxNameLength = 255;
    //public const int MinPasswordLength = 8;
    //public const int MaxPasswordLength = 16;

    //// Genel zamanla ilgili sabitler
    //public const int DefaultTimeoutInSeconds = 30;
    //public const int MaxRetryCount = 3;

    //// Geçerli işlem durumları
    //public const string SuccessStatus = "Success";
    //public const string FailureStatus = "Failure";

    //// Diğer sabitler
    //public const decimal DefaultDiscountRate = 0.05m; // %5 indirim
    //public const int MaxAllowedLoginAttempts = 5;
    //public const string AdminRole = "Admin";
    //public const string UserRole = "User";

    //// İletişim sabitleri
    //public const string SupportEmail = "support@example.com";
    //public const string ContactPhoneNumber = "+1234567890";
}
