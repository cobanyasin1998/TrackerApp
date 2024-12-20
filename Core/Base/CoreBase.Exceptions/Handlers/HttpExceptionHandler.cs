using CoreBase.Exceptions.CustomExceptions;
using CoreBase.Exceptions.MiddlewareExceptions;
using Microsoft.AspNetCore.Http;

namespace CoreBase.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(System.Exception exception, HttpContext context) =>
       exception switch
       {
           BusinessRuleException businessRuleException => HandleException(businessRuleException, context),
           ValidationRuleException validationRuleException => HandleException(validationRuleException, context),
           DataProtectKeyException dataProtectKeyException => HandleException(dataProtectKeyException, context),
           BlackListException blackListRuleException => HandleException(blackListRuleException, context),
           InvalidRequestException invalidRequestException => HandleException(invalidRequestException, context),
           _ => HandleException(exception, context)
       };

    protected abstract Task HandleException(BusinessRuleException exception, HttpContext context);
    protected abstract Task HandleException(ValidationRuleException exception, HttpContext context);
    protected abstract Task HandleException(DataProtectKeyException exception, HttpContext context);
    protected abstract Task HandleException(BlackListException exception, HttpContext context);
    protected abstract Task HandleException(InvalidRequestException exception, HttpContext context);
    protected abstract Task HandleException(System.Exception exception, HttpContext context);



}
