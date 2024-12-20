using CoreBase.Identity.Entities.Base;
using CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;
using CoreOnion.Persistence.EntityFramework.Concretes.Read;
using CoreOnion.Persistence.EntityFramework.Concretes.Write;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Persistence.DbContexts;

namespace Identity.Persistence.EntityFramework;

public class UnitOfWork(IdentityDbContext _context) : IUnitOfWork
{
    public IWriteRepository<UserEntity> UserWriteRepository 
        => new WriteRepository<UserEntity, IdentityDbContext>(_context);


    public IReadRepository<UserEntity> UserReadRepository
        => new ReadRepository<UserEntity, IdentityDbContext>(_context);

    public int SaveChanges()
        => _context.SaveChanges();

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}
