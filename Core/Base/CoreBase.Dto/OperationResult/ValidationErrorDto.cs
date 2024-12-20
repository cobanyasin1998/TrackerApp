namespace CoreBase.Dto.OperationResult;

public record ValidationErrorDto(String Field, String ErrorMessage, String? InvalidValue = null);
