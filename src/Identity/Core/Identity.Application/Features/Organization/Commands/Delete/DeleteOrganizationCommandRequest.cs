using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Dto.Core.EncryptedDto;
using MediatR;

namespace Identity.Application.Features.Organization.Commands.Delete;

public class DeleteOrganizationCommandRequest : EncryptedRequestDto, IRequest<Result<DeleteOrganizationCommandResponse>>
{
}
