using CoreBase.Dto.Core.CoreResponse;
using Identity.Application.Abstractions.UnitOfWork;
using MediatR;

namespace Identity.Application.Features.Organization.Queries.GetAll.UseCase;

public class GetAllOrganizationQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllOrganizationQueryRequest, Result<GetAllOrganizationQueryResponse>>
{
    public Task<Result<GetAllOrganizationQueryResponse>> Handle(GetAllOrganizationQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
