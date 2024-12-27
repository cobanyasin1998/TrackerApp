using CoreBase.Dto.Core.EncryptedDto;

namespace Identity.Application.Features.User.Commands.Create;

public class CreateUserCommandResponse : EncryptedResponseDto
{
    public CreateUserCommandResponse(long Id) 
        => this.Id = Id;

}
