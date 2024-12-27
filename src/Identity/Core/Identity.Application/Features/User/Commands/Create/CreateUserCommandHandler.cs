using AutoMapper;
using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Extensions.Hashing;
using CoreBase.Extensions.Random;
using CoreBase.Identity.Entities.Base;
using CoreOnion.Application.BusinessRule;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.User.Constants;
using Identity.Application.Features.User.Rules.Abstractions;
using MediatR;

namespace Identity.Application.Features.User.Commands.Create;

public class CreateUserCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork,IUserBusinessRule _userBusinessRule)
    : IRequestHandler<CreateUserCommandRequest, BaseResponse<CreateUserCommandResponse>>
{
    public async Task<BaseResponse<CreateUserCommandResponse>> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        await BusinessRuleValidator.CheckRulesAsync(
            () => _userBusinessRule.IsExistsEmailAddress(request.Email)
        );

        UserEntity entity = _mapper.Map<UserEntity>(request);

        HashingHelper.CreatePasswordHash(GeneralRandomHelper.GenerateRandomPassword(), out byte[] passwordHash, out byte[] passwordSalt);

        entity.PasswordHash = passwordHash;
        entity.PasswordSalt = passwordSalt;

        await _unitOfWork.UserWriteRepository.AddAsync(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return BaseResponse<CreateUserCommandResponse>
            .CreateSuccess(new CreateUserCommandResponse(entity.Id), UserConstants.Created);
    }
}
