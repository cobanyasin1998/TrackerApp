using CoreBase.Dto.OperationResult;
using CoreBase.Interfaces.RequestInterfaces;

namespace CoreBase.Dto.Core.CoreResponse;

public class BaseResponse<TData> : CoreResponse,ICoreResponseWithData<TData>,ICoreResponseWithErrors<GeneralErrorDto>
{
    public TData Data { get; set; }
    public List<GeneralErrorDto> Errors { get; set; }


    public static BaseResponse<TData> CreateSuccess(TData data, string message)
    {
        return new BaseResponse<TData>
        {
            Data = data,
            Message = message,
            Success = true
        };
    }
}
