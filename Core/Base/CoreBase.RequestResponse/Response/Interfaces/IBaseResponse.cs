namespace CoreBase.RequestResponse.Response.Interfaces;

public interface IBaseResponse<TData> : IBaseResponseNoData
{
    TData Data { get; set; }

}
