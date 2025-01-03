using CoreBase.Dto.Core.EncryptedDto;

namespace Identity.Application.Features.Organization.Commands.Delete;

public class DeleteOrganizationCommandResponse : EncryptedResponseDto
{
    public DeleteOrganizationCommandResponse(long Id)
    {
        this.Id = Id;
    }
}
