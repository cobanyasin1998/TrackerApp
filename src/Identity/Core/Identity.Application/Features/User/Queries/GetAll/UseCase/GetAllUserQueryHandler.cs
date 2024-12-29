using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Extensions.IQueryable;
using CoreBase.Extensions.Specification;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.User.Queries.GetAll.Specification.CustomSpecification;
using Identity.Application.Features.User.Queries.GetAll.Specification.Factory;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Features.User.Queries.GetAll.UseCase;

public class GetAllUserQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllUserQueryRequest, Result<GetAllUserQueryResponse>>
{
    public async Task<Result<GetAllUserQueryResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        var users = _unitOfWork.UserReadRepository
            .GetAll(tracking: false)
            .ApplySpecification(UserSpecificationFactory.Create(request?.SpecificationFilters));

        List<GetAllUserQueryResponseItemDto> result = await users.Select(u => new GetAllUserQueryResponseItemDto
        {
            FirstName = u.FirstName
        })
        .ApplyPaging(request?.Paging)
        .ToListAsync(cancellationToken);

        return Result<GetAllUserQueryResponse>
            .Success(new GetAllUserQueryResponse(result));
    }
}
