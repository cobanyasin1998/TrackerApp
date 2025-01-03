using AutoMapper;
using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Identity.Entities.Base;
using CoreOnion.Application.BusinessRule;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.Organization.Constants;
using Identity.Application.Features.Organization.Rules.Abstractions;
using MediatR;

namespace Identity.Application.Features.Organization.Commands.Create;

public class CreateOrganizationCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork,IOrganizationBusinessRule _organizationBusinessRule) : IRequestHandler<CreateOrganizationCommandRequest, Result<CreateOrganizationCommandResponse>>
{
    public async Task<Result<CreateOrganizationCommandResponse>> Handle(CreateOrganizationCommandRequest request, CancellationToken cancellationToken)
    {
        await BusinessRuleValidator.CheckRulesAsync(
            () => _organizationBusinessRule.IsExistsCode(request.Code, cancellationToken)
            );

        OrganizationEntity? organizationEntity = _mapper.Map<OrganizationEntity>(request);

        await _unitOfWork.OrganizationWriteRepository.AddAsync(organizationEntity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<CreateOrganizationCommandResponse>
            .Success(new CreateOrganizationCommandResponse(organizationEntity.Id), OrganizationConsts.Created);
    }
}
