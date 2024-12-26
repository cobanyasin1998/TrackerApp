using CoreBase.Interfaces.RequestInterfaces;

namespace CoreBase.Dto.Core.CoreResponse;

public class Response<TData, TError> : CoreResponse, IResponse<TData, TError>
{
    public TData Data { get; set; }
    public List<TError> Errors { get; set; }
}
