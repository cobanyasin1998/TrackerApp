namespace CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

public interface IUnitOfWorkTransaction
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    int SaveChanges();
}
