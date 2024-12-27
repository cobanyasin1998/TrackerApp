using CoreBase.Consts.General;
using CoreBase.Dto.OperationResult;
using CoreBase.Interfaces.RequestInterfaces;
using Microsoft.AspNetCore.Http;

namespace CoreBase.Dto.Core.CoreResponse;

public class BaseResponse<TData> : CoreResponse, ICoreResponseWithData<TData>, ICoreResponseWithErrors<GeneralErrorDto>
{
    public TData Data { get; set; }
    public List<GeneralErrorDto> Errors { get; set; }

    private BaseResponse()
    {
        Success = true;
        Timestamp = DateTime.Now;
        HttpStatusCode = StatusCodes.Status200OK;
    }
    public static BaseResponse<TData> CreateSuccess(TData data)
    {
        return new BaseResponse<TData>
        {
            Data = data,
            Message = GeneralOperationConsts.OperationSuccessfull,
        };
    }
    public static BaseResponse<TData> CreateSuccess(TData data, string message)
    {
        return new BaseResponse<TData>
        {
            Data = data,
            Message = message,
        };
    }
}
