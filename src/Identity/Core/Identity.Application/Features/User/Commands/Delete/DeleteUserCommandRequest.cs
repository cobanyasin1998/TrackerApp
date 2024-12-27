using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Dto.Core.EncryptedDto;
using MediatR;

namespace Identity.Application.Features.User.Commands.Delete;

public class DeleteUserCommandRequest :EncryptedRequestDto, IRequest<Result<DeleteUserCommandResponse>>
{
    
}
