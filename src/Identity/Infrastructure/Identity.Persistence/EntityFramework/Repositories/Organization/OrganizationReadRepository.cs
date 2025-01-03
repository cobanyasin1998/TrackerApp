using CoreBase.Identity.Entities.Base;
using CoreOnion.Persistence.EntityFramework.Concretes.Read;
using Identity.Application.Abstractions.Repositories.Organization;
using Identity.Persistence.DbContexts;

namespace Identity.Persistence.EntityFramework.Repositories.Organization;

public class OrganizationReadRepository(IdentityDbContext context) : ReadRepository<OrganizationEntity, IdentityDbContext>(context), IOrganizationReadRepository
{
}
