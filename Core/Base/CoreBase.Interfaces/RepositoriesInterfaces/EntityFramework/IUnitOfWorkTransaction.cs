namespace CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

public interface IUnitOfWorkTransaction
{
    Task<Int32> SaveChangesAsync(CancellationToken cancellationToken);
    Int32 SaveChanges();
}
