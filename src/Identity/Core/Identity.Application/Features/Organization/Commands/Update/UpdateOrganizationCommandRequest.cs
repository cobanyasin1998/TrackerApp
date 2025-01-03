using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Dto.Core.EncryptedDto;
using MediatR;

namespace Identity.Application.Features.Organization.Commands.Update;

public class UpdateOrganizationCommandRequest : EncryptedRequestDto, IRequest<Result<UpdateOrganizationCommandResponse>>
{
}
