namespace CoreBase.Interfaces.RequestInterfaces;

public interface ICoreResponseWithData<TData> : ICoreResponse
{
    TData Data { get; set; }

}
