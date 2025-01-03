using CoreBase.Identity.Entities.Base;
using CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

namespace Identity.Application.Abstractions.Repositories.Organization;

public interface IOrganizationReadRepository : IReadRepository<OrganizationEntity>
{
}
