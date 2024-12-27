using CoreBase.Enums.Exceptions;
using CoreBase.Interfaces.RequestInterfaces;

namespace CoreBase.Dto.Core.CoreResponse;

public class CoreResponseWithErrors<TError> : CoreResponse, ICoreResponseWithErrors<TError>
{
    public List<TError> Errors { get ; set ; }

    public static CoreResponseWithErrors<TError> CreateFailure(
       List<TError> errors,
       string message,
       EErrorType errorType,
       int httpStatusCode)
    {
        return new CoreResponseWithErrors<TError>
        {
            Errors = errors ?? [],
            Message = message,
            ErrorType = errorType,
            HttpStatusCode = httpStatusCode,
            IsSuccess = false
        };
    }
}
