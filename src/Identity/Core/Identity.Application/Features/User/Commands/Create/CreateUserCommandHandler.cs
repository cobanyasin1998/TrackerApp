using AutoMapper;
using CoreBase.Dto.OperationResult;
using CoreBase.Identity.Entities.Base;
using CoreBase.RequestResponse.Response.Concretes;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.User.Constants;
using MediatR;

namespace Identity.Application.Features.User.Commands.Create;

public class CreateUserCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork) : IRequestHandler<CreateUserCommandRequest, BaseResponse<CreateUserCommandResponse>>
{
    public async Task<BaseResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        UserEntity entity = _mapper.Map<UserEntity>(request);

        await _unitOfWork.UserWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return BaseResponse<CreateUserCommandResponse>
            .CreateSuccess(new CreateUserCommandResponse(entity.Id), UserConstants.Created);
    }
}
