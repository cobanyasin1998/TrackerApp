using CoreBase.Identity.Entities.Base;
using CoreOnion.Persistence.EntityFramework.Concretes.Write;
using Identity.Application.Abstractions.Repositories.User;
using Identity.Persistence.DbContexts;

namespace Identity.Persistence.EntityFramework.Repositories.User;

public class UserWriteRepository(IdentityDbContext context) : WriteRepository<UserEntity, IdentityDbContext>(context), IUserWriteRepository
{
}
