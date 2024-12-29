using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Dto.RequestResponse.Response.GetAll;
using Identity.Application.Features.User.Queries.GetAll.Specification;
using MediatR;

namespace Identity.Application.Features.User.Queries.GetAll.UseCase;

public class GetAllUserQueryRequest : FullRequestDto, IRequest<Result<GetAllUserQueryResponse>>
{
    public UserGetAllFiltersDto? SpecificationFilters  { get; set; }

}
