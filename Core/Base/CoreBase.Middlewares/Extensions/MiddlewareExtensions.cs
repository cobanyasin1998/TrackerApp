using CoreBase.Middlewares.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace CoreBase.Middlewares.Extensions;

public static class MiddlewareExtensions
{
    #region Validation Middlewares
    // Request ve Response doğrulama işlemleri
    public static void ConfigureAdvancedRequestValidationMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<AdvancedRequestValidationMiddleware>();

    public static void ConfigureAdvancedResponseValidationMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<AdvancedResponseValidationMiddleware>();
    #endregion

    #region Security Middlewares
    // Güvenlik işlemleri: Kara liste kontrolü ve bot tespiti
    public static void ConfigureBlackListControlMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<BlackListControlMiddleware>();

    public static void ConfigureBotDetectionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<BotDetectionMiddleware>();
    #endregion

    #region Identification and Tracking Middlewares
    // Kimlik doğrulama ve izleme işlemleri
    public static void ConfigureCorrelationIdMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<CorrelationIdMiddleware>();
    #endregion

    #region Error Handling and Maintenance Middlewares
    // Hata işleme ve bakım modülleri
    public static void ConfigureExceptionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionMiddleware>();

    public static void ConfigureMaintenanceMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<MaintenanceMiddleware>();
    #endregion

    #region Performance and Size Control Middlewares
    // Performans izleme ve istek boyutu kontrolü
    public static void ConfigureMaxRequestSizeMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<MaxRequestSizeMiddleware>();

    public static void ConfigurePerformanceWatchMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<PerformanceWatchMiddleware>();
    #endregion

    #region Request Handling Middlewares
    // İstek tekrarı kontrolü ve logging işlemleri
    public static void ConfigureRequestDeduplicationMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<RequestDeduplicationMiddleware>();

    public static void ConfigureRequestResponseLoggingMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<RequestResponseLoggingMiddleware>();
    #endregion
}
