using CoreBase.Dto.OperationResult;

namespace CoreBase.Exceptions.CustomExceptions;

public class ValidationRuleException(List<ValidationErrorDto> errorDetails) : Exception("Validation rules are incorrect")
{
    public List<ValidationErrorDto> ErrorDetails { get; } = errorDetails;
}
