using CoreBase.Dto.IQueryable.Paged;
using CoreBase.Dto.RequestResponse.Response.GetAll;
using CoreBase.Identity.Entities.Base;
using CoreBase.Interfaces.DtoInterfaces;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Features.User.Queries.GetAll.UseCase;

public class GetAllUserQueryResponse : GetAllResultDto<GetAllUserQueryResponseItemDto>
{
    public GetAllUserQueryResponse(List<GetAllUserQueryResponseItemDto> dtos, int totalPage, int totalCount) : base(dtos, totalPage, totalCount)
    {
        this.Result = dtos;
        this.TotalCount = totalCount;
        this.TotalPage = totalPage;
    }
}
public class GetAllUserQueryResponseItemDto : IDto
{
    public string? FirstName { get; set; }
}