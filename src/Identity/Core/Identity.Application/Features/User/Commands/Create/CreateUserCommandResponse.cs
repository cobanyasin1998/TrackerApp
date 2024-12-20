using CoreBase.RequestResponse.Response.Concretes;

namespace Identity.Application.Features.User.Commands.Create;

public class CreateUserCommandResponse : EncResponse
{
    public CreateUserCommandResponse(long Id)
    {
        this.Id = Id;
    }
}
