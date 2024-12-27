using AutoMapper;
using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Events;
using CoreBase.Extensions.Hashing;
using CoreBase.Extensions.Random;
using CoreBase.Identity.Entities.Base;
using CoreBase.Interfaces.ServiceBusInterfaces;
using CoreOnion.Application.BusinessRule;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.User.Constants;
using Identity.Application.Features.User.Rules.Abstractions;
using MediatR;

namespace Identity.Application.Features.User.Commands.Create;

public class CreateUserCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork, IUserBusinessRule _userBusinessRule, IServiceBus _serviceBus)
    : IRequestHandler<CreateUserCommandRequest, Result<CreateUserCommandResponse>>
{
    public async Task<Result<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        await BusinessRuleValidator.CheckRulesAsync(
            () => _userBusinessRule.IsExistsEmailAddress(request.Email)
            );

        var userEntity = _mapper.Map<UserEntity>(request);

        var pwd = GeneralRandomHelper.GenerateRandomPassword();
        (userEntity.PasswordHash, userEntity.PasswordSalt) = HashingHelper.CreatePasswordHash(pwd);
        userEntity.Username = request.Email;

        await _unitOfWork.UserWriteRepository.AddAsync(userEntity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        await _serviceBus.PublishAsync(new UserAddedEvent(Email: request.Email, Password: pwd), cancellationToken);

        return Result<CreateUserCommandResponse>
            .Success(new CreateUserCommandResponse(userEntity.Id), UserConstants.Created);
    }
}

