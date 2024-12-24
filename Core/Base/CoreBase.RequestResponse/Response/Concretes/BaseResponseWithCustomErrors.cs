using CoreBase.Consts.General;
using CoreBase.Enums.Exceptions;
using CoreBase.RequestResponse.Response.Interfaces;

namespace CoreBase.RequestResponse.Response.Concretes;

public class BaseResponseWithCustomErrors<TError> : IBaseResponseWithCustomErrors<TError>
{
    public List<TError> Errors { get; set; } = [];
    public bool Success { get; set; } = false;
    public string Message { get; set; } = GeneralOperationConsts.OperationFailed;
    public int HttpStatusCode { get; set; } = 400;
    public DateTime Timestamp { get; set; }
    public EErrorType? ErrorType { get; set; } = EErrorType.BadRequest;


    public static BaseResponseWithCustomErrors<TError> CreateFailure(
        List<TError> errors,
        string message,
        EErrorType errorType,
        int httpStatusCode)
    {
        return new BaseResponseWithCustomErrors<TError>
        {
            Errors = errors,
            Message = message,
            ErrorType = errorType,
            HttpStatusCode = httpStatusCode,
            Success = false,
            Timestamp = DateTime.UtcNow
        };
    }
}
