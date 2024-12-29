namespace CoreBase.Interfaces.RequestInterfaces;

public interface IResponse<TData,TError> : ICoreResponseWithData<TData>,ICoreResponseWithErrors<TError>
{
}
