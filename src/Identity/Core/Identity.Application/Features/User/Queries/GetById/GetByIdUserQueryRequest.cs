using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Dto.Core.EncryptedDto;
using MediatR;

namespace Identity.Application.Features.User.Queries.GetById;

public class GetByIdUserQueryRequest : EncryptedRequestDto, IRequest<Result<GetByIdUserQueryResponse>>;