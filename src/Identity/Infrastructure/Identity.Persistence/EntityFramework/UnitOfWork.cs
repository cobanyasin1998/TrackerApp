using Identity.Application.Abstractions.Repositories.User;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Persistence.DbContexts;
using Identity.Persistence.EntityFramework.Repositories.User;

namespace Identity.Persistence.EntityFramework;

public class UnitOfWork(IdentityDbContext _context) : IUnitOfWork
{
    public IUserWriteRepository UserWriteRepository
        => new UserWriteRepository(_context);


    public IUserReadRepository UserReadRepository
          => new UserReadRepository(_context);

    public int SaveChanges()
        => _context.SaveChanges();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
