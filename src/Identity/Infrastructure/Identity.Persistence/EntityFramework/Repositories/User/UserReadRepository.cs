using CoreBase.Identity.Entities.Base;
using CoreOnion.Persistence.EntityFramework.Concretes.Read;
using Identity.Application.Abstractions.Repositories.User;
using Identity.Persistence.DbContexts;

namespace Identity.Persistence.EntityFramework.Repositories.User;

public class UserReadRepository(IdentityDbContext context) : ReadRepository<UserEntity, IdentityDbContext>(context), IUserReadRepository
{
}
