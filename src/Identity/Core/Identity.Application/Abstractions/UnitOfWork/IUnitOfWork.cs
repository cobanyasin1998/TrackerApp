using CoreBase.Identity.Entities.Base;
using CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

namespace Identity.Application.Abstractions.UnitOfWork;

public interface IUnitOfWork : IUnitOfWorkTransaction
{
    IWriteRepository<UserEntity> UserWriteRepository { get; }
    IReadRepository<UserEntity> UserReadRepository { get; }
}
