using CoreBase.Dto.OperationResult;
using CoreBase.Exceptions.CustomExceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CoreOnion.Application.Mediatr.Pipelines;

public class RequestValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> _validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        ValidationContext<object> context = new(request);

        List<ValidationFailure> validationResults = _validators
            .Select(validator => validator.Validate(context))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null)
            .ToList();

        if (validationResults.Count == 0)
            return await next();

        List<ValidationErrorDto> errorResponse = CreateValidationErrorResponse(validationResults);
        throw new ValidationRuleException(errorResponse);

    }

    private static List<ValidationErrorDto> CreateValidationErrorResponse(IEnumerable<ValidationFailure> failures)
    {
        return failures
            .GroupBy(failure => failure.PropertyName)
            .Select(group => new ValidationErrorDto(
                Field: group.Key,
                ErrorMessage: group.First().ErrorMessage,
                InvalidValue: group.First().AttemptedValue?.ToString()))
            .ToList();
    }
}
