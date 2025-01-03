using CoreBase.Interfaces.BusinessInterfaces;

namespace Identity.Application.Features.Organization.Rules.Abstractions;

public interface IOrganizationBusinessRule : IBaseBusinessRule
{
    Task IsExistsCode(string code, CancellationToken cancellationToken = default);
    Task IsExistsCode(string code, long id, CancellationToken cancellationToken = default);

}
