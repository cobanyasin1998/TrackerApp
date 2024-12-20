using CoreBase.RequestResponse.Response.Concretes;
using MediatR;

namespace Identity.Application.Features.User.Commands.Create;

public class CreateUserCommandRequest : IRequest<BaseResponse<CreateUserCommandResponse>>
{
}
