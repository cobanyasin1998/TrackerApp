namespace CoreBase.Dto.RequestResponse.Response.GetAll;


public class GetAllResultDto<T>
{
    public List<T> Result { get; set; } = [];
    public int TotalCount { get; set; }
    public int TotalPage { get; set; }
}
