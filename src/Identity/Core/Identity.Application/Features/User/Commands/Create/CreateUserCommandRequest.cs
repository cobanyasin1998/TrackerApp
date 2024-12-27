using CoreBase.Dto.Core.CoreResponse;
using MediatR;

namespace Identity.Application.Features.User.Commands.Create;

public class CreateUserCommandRequest : IRequest<Result<CreateUserCommandResponse>>
{
    public required long OrganizationEntityId { get; set; }
    public required string Email { get; set; }
}
