using CoreBase.Consts.General;
using CoreBase.Dto.OperationResult;
using CoreBase.Interfaces.RequestInterfaces;
using Microsoft.AspNetCore.Http;

namespace CoreBase.Dto.Core.CoreResponse;

public class Result<TData> : CoreResponse, ICoreResponseWithData<TData>, ICoreResponseWithErrors<GeneralErrorDto>
{
    public TData Data { get; set; }
    public List<GeneralErrorDto> Errors { get; set; }

    private Result()
    {
        IsSuccess = true;
        Timestamp = DateTime.Now;
        HttpStatusCode = StatusCodes.Status200OK;
    }

    public static new Result<TData> Success(TData data)
    {
        return new Result<TData>
        {
            Data = data,
            Message = GeneralOperationConsts.OperationSuccessfull,
        };
    }

    public static new  Result<TData> Success(TData data, string message)
    {
        return new Result<TData>
        {
            Data = data,
            Message = message,
        };
    }

    public static Result<TData> Failure(string message, List<GeneralErrorDto>? errors = null, int httpStatusCode = StatusCodes.Status400BadRequest)
    {
        return new Result<TData>
        {
            IsSuccess = false,
            Message = message,
            Errors = errors ?? [],
            HttpStatusCode = httpStatusCode,
        };
    }

    public static Result<TData> NotFoundRecord(string message, List<GeneralErrorDto>? errors = null)
    {
        return new Result<TData>
        {
            IsSuccess = false,
            Message = message,
            Errors = errors ?? [],
            HttpStatusCode = StatusCodes.Status404NotFound,
        };
    }
}