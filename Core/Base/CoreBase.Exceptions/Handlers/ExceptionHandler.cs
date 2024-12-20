using CoreBase.Consts.General;
using CoreBase.Exceptions.CustomExceptions;
using CoreBase.Exceptions.MiddlewareExceptions;
using Microsoft.AspNetCore.Http;

namespace CoreBase.Exceptions.Handlers;

//public class HttpExceptionHandler : ExceptionHandler
//{
//    private static readonly Dictionary<Type, (ErrorType errorType, int httpStatusCode)> ExceptionMappings = new()
//{
//    { typeof(BusinessRuleException), (ErrorType.BusinessRuleViolation, StatusCodes.Status400BadRequest) },
//    { typeof(ValidationRuleException), (ErrorType.BusinessRuleViolation, StatusCodes.Status400BadRequest) },
//    { typeof(BlackListRuleException), (ErrorType.AccessDenied, StatusCodes.Status403Forbidden) },
//    { typeof(DataProtectKeyException), (ErrorType.BusinessRuleViolation, StatusCodes.Status400BadRequest) },
//    { typeof(InvalidRequestException), (ErrorType.BadRequest, StatusCodes.Status400BadRequest) }
//};

//private static Task WriteErrorResponse<TError>(HttpContext context, string message, ErrorType errorType, int httpStatusCode, List<TError> errors)
//    {
//        var response = Response<object, TError>.CreateFailure(
//            errors: errors,
//            message: message,
//            errorType: errorType,
//            httpStatusCode: httpStatusCode
//        );

//        context.Response.StatusCode = httpStatusCode;
//        context.Response.ContentType = GeneralOperationConsts.ApplicationJsonKey;
//        return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
//    }
//    protected override Task HandleException(BusinessRuleException exception, HttpContext context)
//        => WriteErrorResponse(context, exception.Message, ErrorType.BusinessRuleViolation, StatusCodes.Status400BadRequest, CreateErrorDetails(exception));

//    protected override Task HandleException(ValidationRuleException exception, HttpContext context)
//        => WriteErrorResponse(context, exception.Message, ErrorType.BusinessRuleViolation, StatusCodes.Status400BadRequest, exception.ErrorDetails);

//    protected override Task HandleException(BlackListRuleException exception, HttpContext context)
//        => WriteErrorResponse(context, exception.Message, ErrorType.AccessDenied, StatusCodes.Status403Forbidden, CreateErrorDetails(exception));

//    protected override Task HandleException(DataProtectKeyException exception, HttpContext context)
//        => WriteErrorResponse(context, exception.Message, ErrorType.BusinessRuleViolation, StatusCodes.Status400BadRequest, CreateErrorDetails(exception));

//    private List<object> CreateErrorDetails(Exception? exception)
//    {
//        throw new NotImplementedException();
//    }

//    protected override Task HandleException(InvalidRequestException exception, HttpContext context)
//        => WriteErrorResponse(context, exception.Message, ErrorType.BadRequest, StatusCodes.Status400BadRequest, CreateErrorDetails(exception));

//    protected override Task HandleException(Exception exception, HttpContext context)
//        => WriteErrorResponse(context, exception.Message, ErrorType.InternalServerError, StatusCodes.Status500InternalServerError, CreateErrorDetails(exception));


//}
