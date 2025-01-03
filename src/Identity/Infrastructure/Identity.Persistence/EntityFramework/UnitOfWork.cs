using Identity.Application.Abstractions.Repositories.Organization;
using Identity.Application.Abstractions.Repositories.User;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Persistence.DbContexts;
using Identity.Persistence.EntityFramework.Repositories.Organization;
using Identity.Persistence.EntityFramework.Repositories.User;

namespace Identity.Persistence.EntityFramework;

public class UnitOfWork(IdentityDbContext _context) : IUnitOfWork
{
    public IUserWriteRepository UserWriteRepository
        => new UserWriteRepository(_context);


    public IUserReadRepository UserReadRepository
          => new UserReadRepository(_context);

    public IOrganizationWriteRepository OrganizationWriteRepository
        => new OrganizationWriteRepository(_context);

    public IOrganizationReadRepository OrganizationReadRepository
        => new OrganizationReadRepository(_context);

    public int SaveChanges()
        => _context.SaveChanges();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
