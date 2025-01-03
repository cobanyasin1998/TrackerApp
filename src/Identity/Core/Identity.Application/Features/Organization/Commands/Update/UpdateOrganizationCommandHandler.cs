using AutoMapper;
using CoreBase.Dto.Core.CoreResponse;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.Organization.Rules.Abstractions;
using MediatR;

namespace Identity.Application.Features.Organization.Commands.Update;

public class UpdateOrganizationCommandHandler(IMapper _mapper, IUnitOfWork _unitOfWork, IOrganizationBusinessRule _organizationBusinessRule)
     : IRequestHandler<UpdateOrganizationCommandRequest, Result<UpdateOrganizationCommandResponse>>
{
    public Task<Result<UpdateOrganizationCommandResponse>> Handle(UpdateOrganizationCommandRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
