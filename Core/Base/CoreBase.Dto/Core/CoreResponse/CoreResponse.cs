using CoreBase.Enums.Exceptions;
using CoreBase.Interfaces.RequestInterfaces;

namespace CoreBase.Dto.Core.CoreResponse;

public class CoreResponse : ICoreResponse
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int HttpStatusCode { get; set; }
    public DateTime Timestamp { get; set; }
    public EErrorType? ErrorType { get; set; }
}
