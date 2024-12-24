using CoreBase.Consts.General;
using CoreBase.Enums.Exceptions;
using CoreBase.Exceptions.CustomExceptions;
using CoreBase.Exceptions.MiddlewareExceptions;
using CoreBase.Extensions.Json;
using CoreBase.RequestResponse.Response.Concretes;
using Microsoft.AspNetCore.Http;

namespace CoreBase.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    private static Task WriteErrorResponse<TError>(HttpContext context, string message, EErrorType errorType, int httpStatusCode, List<TError> errors)
    {
        var response = BaseResponseWithCustomErrors<TError>.CreateFailure(
            errors: errors,
            message: message,
            errorType: errorType,
            httpStatusCode: httpStatusCode
        );

        context.Response.StatusCode = httpStatusCode;
        context.Response.ContentType = GeneralOperationConsts.ApplicationJsonKey;
        return context.Response.WriteAsync(response.ToJson());
    }

    //protected override Task HandleException(BusinessRuleException exception, HttpContext context)
    //{
    //    throw new NotImplementedException();
    //}

    protected override Task HandleException(ValidationRuleException exception, HttpContext context)
    {
        throw new NotImplementedException();
    }

    protected override Task HandleException(DataProtectKeyException exception, HttpContext context)
    {
        throw new NotImplementedException();
    }

    protected override Task HandleException(BlackListException exception, HttpContext context)
    {
        throw new NotImplementedException();
    }

    protected override Task HandleException(InvalidRequestException exception, HttpContext context)
    {
        throw new NotImplementedException();
    }

    protected override Task HandleException(Exception exception, HttpContext context)
    {
        throw new NotImplementedException();
    }

    protected override Task HandleException(BusinessRuleException exception, HttpContext context)
        => WriteErrorResponse(context, exception.Message, EErrorType.BadRequest, StatusCodes.Status400BadRequest, CreateErrorDetails(exception));

    private static List<string> CreateErrorDetails(Exception exception)
        => [exception.Message ?? exception.InnerException?.Message ?? GeneralOperationConsts.AnErrorOccurred];

}
