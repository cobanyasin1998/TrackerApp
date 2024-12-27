using CoreBase.Dto.Core.EncryptedDto;

namespace Identity.Application.Features.User.Commands.Update;

public class UpdateUserCommandResponse : EncryptedResponseDto
{
    public UpdateUserCommandResponse(long Id) 
        => this.Id = Id;
}
