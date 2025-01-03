using CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;
using Identity.Application.Abstractions.Repositories.Organization;
using Identity.Application.Abstractions.Repositories.User;

namespace Identity.Application.Abstractions.UnitOfWork;

public interface IUnitOfWork : IUnitOfWorkTransaction
{
    IUserWriteRepository UserWriteRepository { get; }
    IUserReadRepository UserReadRepository { get; }

    IOrganizationWriteRepository OrganizationWriteRepository { get; }
    IOrganizationReadRepository OrganizationReadRepository { get; }

}
