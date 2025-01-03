using CoreBase.Dto.Core.EncryptedDto;

namespace Identity.Application.Features.Organization.Commands.Create;

public class CreateOrganizationCommandResponse : EncryptedResponseDto
{
    public CreateOrganizationCommandResponse(long Id)
        => this.Id = Id;

}
