using CoreBase.Interfaces.DtoInterfaces;

namespace CoreBase.Dto.RequestResponse.Response.GetAll;


public class GetAllResultDto<TDto>(List<TDto> result, int totalPage, int totalCount)
    where TDto : IDto
{
    public List<TDto> Result { get; set; } = result;
    public Int32 TotalCount { get; set; } = totalCount;
    public Int32 TotalPage { get; set; } = totalPage;
}
