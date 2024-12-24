using CoreBase.Dto.OperationResult;
using CoreBase.Enums.Exceptions;

namespace CoreBase.RequestResponse.Response.Interfaces;

public interface IBaseResponseWithCustomErrors<TError>
{
    List<TError> Errors { get; set; }
    bool Success { get; set; }
    string Message { get; set; }
    int HttpStatusCode { get; set; }
    DateTime Timestamp { get; set; }
    EErrorType? ErrorType { get; set; }
}
