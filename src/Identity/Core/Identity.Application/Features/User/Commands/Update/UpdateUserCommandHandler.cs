using AutoMapper;
using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Identity.Entities.Base;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.User.Constants;
using Identity.Application.Features.User.Rules.Abstractions;
using MediatR;

namespace Identity.Application.Features.User.Commands.Update;

public class UpdateUserCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork, IUserBusinessRule _userBusinessRule)
     : IRequestHandler<UpdateUserCommandRequest, Result<UpdateUserCommandResponse>>
{
    public async Task<Result<UpdateUserCommandResponse>> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
    {
       
        UserEntity? user = await _unitOfWork.UserReadRepository.FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken);

        if (user == null) 
            return Result<UpdateUserCommandResponse>.NotFoundRecord(UserConstants.NotFound);

        
        _mapper.Map(request, user);

        await _unitOfWork.UserWriteRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<UpdateUserCommandResponse>.Success(new UpdateUserCommandResponse(user.Id), UserConstants.Updated);

       
    }
}
