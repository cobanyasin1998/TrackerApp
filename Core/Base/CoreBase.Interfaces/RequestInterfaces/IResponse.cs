namespace CoreBase.Interfaces.RequestInterfaces;

public interface IResponse<TData,TError> : ICoreResponse,ICoreResponseWithData<TData>,ICoreResponseWithErrors<TError>
{
}
