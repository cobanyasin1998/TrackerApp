using CoreBase.Dto.Core.CoreResponse;
using CoreBase.Extensions.IQueryable;
using CoreBase.Extensions.Specification;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.User.Queries.GetAll.Specification.Factory;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Features.User.Queries.GetAll.UseCase;

public class GetAllUserQueryHandler(IUnitOfWork _unitOfWork) : IRequestHandler<GetAllUserQueryRequest, Result<GetAllUserQueryResponse>>
{
    public async Task<Result<GetAllUserQueryResponse>> Handle(GetAllUserQueryRequest request, CancellationToken cancellationToken)
    {
        var users = _unitOfWork.UserReadRepository.GetAll(tracking: false);

        var filteringCount = users;

        List<GetAllUserQueryResponseItemDto> result = await filteringCount
            .ApplySpecification(UserSpecificationFactory.Create(request?.SpecificationFilters))
            .Select(u => new GetAllUserQueryResponseItemDto
            {
                FirstName = u.FirstName
            })
        .ApplyPaging(request?.Paging)
        .ToListAsync(cancellationToken);
        var totalCount =await users.CountAsync(cancellationToken);
        var asd = new GetAllUserQueryResponse(result, totalCount, totalCount);
        return Result<GetAllUserQueryResponse>
            .Success(asd);
    }
}
