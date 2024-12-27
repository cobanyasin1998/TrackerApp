using CoreBase.Dto.Core.EncryptedDto;

namespace Identity.Application.Features.User.Commands.Delete;

public class DeleteUserCommandResponse : EncryptedResponseDto
{
    public DeleteUserCommandResponse(long Id)
    {
        this.Id = Id;
    }
}
