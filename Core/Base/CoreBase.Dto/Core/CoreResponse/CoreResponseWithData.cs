using CoreBase.Interfaces.RequestInterfaces;

namespace CoreBase.Dto.Core.CoreResponse;

public class CoreResponseWithData<TData> : CoreResponse, ICoreResponseWithData<TData>
{
    public TData Data { get; set; }
}