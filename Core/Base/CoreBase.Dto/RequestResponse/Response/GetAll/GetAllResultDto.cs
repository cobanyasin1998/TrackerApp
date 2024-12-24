namespace CoreBase.Dto.RequestResponse.Response.GetAll;


public class GetAllResultDto<T>
{
    public List<T> Result { get; set; } = [];
    public Int32 TotalCount { get; set; }
    public Int32 TotalPage { get; set; }
}
