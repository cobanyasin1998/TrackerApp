using CoreBase.Enums.Exceptions;

namespace CoreBase.Interfaces.RequestInterfaces;

public interface ICoreResponse
{
    bool Success { get; set; }
    string Message { get; set; }
    int HttpStatusCode { get; set; }
    DateTime Timestamp { get; set; }
    EErrorType? ErrorType { get; set; }
}
