using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Identity.Entities.Base;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.Organization.Constants;
using Identity.Application.Features.User.Commands.Delete;
using Identity.Application.Features.User.Constants;
using MediatR;

namespace Identity.Application.Features.Organization.Commands.Delete;

public class DeleteOrganizationCommandHandler(IUnitOfWork _unitOfWork)  : IRequestHandler<DeleteOrganizationCommandRequest, Result<DeleteOrganizationCommandResponse>>
{
    public async Task<Result<DeleteOrganizationCommandResponse>> Handle(DeleteOrganizationCommandRequest request, CancellationToken cancellationToken)
    {
        OrganizationEntity? organizationEntity = await _unitOfWork.OrganizationReadRepository.FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken);

        if (organizationEntity is null)
            return Result<DeleteOrganizationCommandResponse>.NotFoundRecord(OrganizationConsts.NotFound);


        await _unitOfWork.OrganizationWriteRepository.DeleteAsync(organizationEntity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<DeleteOrganizationCommandResponse>.Success(new DeleteOrganizationCommandResponse(organizationEntity.Id), UserConstants.Deleted);
    }
}
