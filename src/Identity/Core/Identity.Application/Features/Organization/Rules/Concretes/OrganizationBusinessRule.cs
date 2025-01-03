using CoreBase.Exceptions.CustomExceptions;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.Organization.Rules.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Features.Organization.Rules.Concretes;

public class OrganizationBusinessRule(IUnitOfWork _unitOfWork) : IOrganizationBusinessRule
{
    public async Task IsExistsCode(string code, CancellationToken cancellationToken = default)
    {
        var isexist = await _unitOfWork.OrganizationReadRepository.GetWhere(y => y.Code == code).AnyAsync(cancellationToken);
        if (isexist)
            throw new BusinessRuleException("Code already exists.");

    }

    public async Task IsExistsCode(string code, long id, CancellationToken cancellationToken = default)
    {
        var isexist = await _unitOfWork.OrganizationReadRepository.GetWhere(y => y.Code == code && y.Id != id).AnyAsync(cancellationToken);
        if (isexist)
            throw new BusinessRuleException("Code already exists.");
    }
}
