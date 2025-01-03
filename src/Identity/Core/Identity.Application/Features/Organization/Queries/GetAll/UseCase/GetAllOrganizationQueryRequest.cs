using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Dto.RequestResponse.Response.GetAll;
using MediatR;

namespace Identity.Application.Features.Organization.Queries.GetAll.UseCase;

public class GetAllOrganizationQueryRequest
: FullRequestDto, IRequest<Result<GetAllOrganizationQueryResponse>>
{

}
