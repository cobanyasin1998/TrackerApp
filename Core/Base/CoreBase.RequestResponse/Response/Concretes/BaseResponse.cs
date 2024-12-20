using CoreBase.Consts.General;
using CoreBase.Dto.OperationResult;
using CoreBase.Enums.Exceptions;
using CoreBase.RequestResponse.Response.Interfaces;

namespace CoreBase.RequestResponse.Response.Concretes;

public class BaseResponse<TData> : IBaseResponse<TData>
{
    public TData Data { get; set; }
    public List<GeneralErrorDto> Errors { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public int HttpStatusCode { get; set; }
    public DateTime Timestamp { get; set; }
    public EErrorType? ErrorType { get; set; }

    private BaseResponse()
    {
        Timestamp = DateTime.UtcNow;
        Errors = new List<GeneralErrorDto>();
        ErrorType = null;
        Success = false;
        Message = GeneralOperationConsts.OperationFailed;
    }
  
    public static BaseResponse<TData> CreateSuccess(TData data)
    {
        return new BaseResponse<TData>
        {
            Data = data,
            Success = true,
            Message = GeneralOperationConsts.OperationSuccessfull,
            HttpStatusCode = 200
        };
    }
    public static BaseResponse<TData> CreateSuccess(TData data, string message)
    {
        return new BaseResponse<TData>
        {
            Data = data,
            Success = true,
            Message = message,
            HttpStatusCode = 200,

        };
    }
    public static BaseResponse<TData> CreateFailure(string message, int httpStatusCode, EErrorType? errorType = null)
    {
        return new BaseResponse<TData>
        {
            Message = message,
            HttpStatusCode = httpStatusCode,
            ErrorType = errorType
        };
    }
    public void AddError(string errorMessage, string? errorCode)
        => Errors.Add(new GeneralErrorDto(ErrorMessage: errorMessage, Details: errorCode));
    public void SetErrorType(EErrorType errorType) 
        => ErrorType = errorType;
}
