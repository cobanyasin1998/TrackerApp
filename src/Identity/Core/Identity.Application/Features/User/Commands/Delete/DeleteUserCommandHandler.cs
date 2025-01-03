﻿using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Identity.Entities.Base;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.User.Constants;
using MediatR;

namespace Identity.Application.Features.User.Commands.Delete;

public class DeleteUserCommandHandler(IUnitOfWork _unitOfWork)
    : IRequestHandler<DeleteUserCommandRequest, Result<DeleteUserCommandResponse>>
{
    public async Task<Result<DeleteUserCommandResponse>> Handle(DeleteUserCommandRequest request, CancellationToken cancellationToken)
    {
        UserEntity? user = await _unitOfWork.UserReadRepository.FirstOrDefaultAsync(user => user.Id == request.Id,cancellationToken);

        if (user is null)
            return Result<DeleteUserCommandResponse>.NotFoundRecord(UserConstants.NotFound);
        

        await _unitOfWork.UserWriteRepository.DeleteAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<DeleteUserCommandResponse>.Success(new DeleteUserCommandResponse(user.Id), UserConstants.Deleted);
    }
}
