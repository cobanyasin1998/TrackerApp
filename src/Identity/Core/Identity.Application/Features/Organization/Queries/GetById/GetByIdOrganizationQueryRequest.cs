using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Dto.Core.EncryptedDto;
using MediatR;

namespace Identity.Application.Features.Organization.Queries.GetById;

public class GetByIdOrganizationQueryRequest : EncryptedRequestDto, IRequest<Result<GetByIdOrganizationQueryResponse>>;
