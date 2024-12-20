using CoreBase.Identity.Entities.Base;
using CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

namespace Identity.Application.Abstractions.Repositories.User;


public interface IUserReadRepository : IReadRepository<UserEntity>
{
}
