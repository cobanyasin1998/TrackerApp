using CoreBase.Dto.Core.EncryptedDto;

namespace Identity.Application.Features.Organization.Commands.Update;

public class UpdateOrganizationCommandResponse
: EncryptedResponseDto
{
    public UpdateOrganizationCommandResponse(long Id)
        => this.Id = Id;
}
