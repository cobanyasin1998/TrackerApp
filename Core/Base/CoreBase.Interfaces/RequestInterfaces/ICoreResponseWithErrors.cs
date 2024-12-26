namespace CoreBase.Interfaces.RequestInterfaces;

public interface ICoreResponseWithErrors<TError> : ICoreResponse
{
    List<TError> Errors { get; set; }

}
