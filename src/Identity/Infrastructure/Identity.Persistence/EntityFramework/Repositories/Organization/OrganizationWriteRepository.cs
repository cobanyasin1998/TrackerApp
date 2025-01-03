using CoreBase.Identity.Entities.Base;
using CoreOnion.Persistence.EntityFramework.Concretes.Write;
using Identity.Application.Abstractions.Repositories.Organization;
using Identity.Persistence.DbContexts;

namespace Identity.Persistence.EntityFramework.Repositories.Organization;

public class OrganizationWriteRepository(IdentityDbContext context) : WriteRepository<OrganizationEntity, IdentityDbContext>(context), IOrganizationWriteRepository
{
}
