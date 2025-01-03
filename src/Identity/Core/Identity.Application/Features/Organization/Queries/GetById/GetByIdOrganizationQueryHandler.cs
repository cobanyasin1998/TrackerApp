using AutoMapper;
using CoreBase.Dto.Core.CoreResponse;
using Identity.Application.Abstractions.UnitOfWork;
using MediatR;

namespace Identity.Application.Features.Organization.Queries.GetById;

public class GetByIdOrganizationQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper) : IRequestHandler<GetByIdOrganizationQueryRequest, Result<GetByIdOrganizationQueryResponse>>
{
    public Task<Result<GetByIdOrganizationQueryResponse>> Handle(GetByIdOrganizationQueryRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
