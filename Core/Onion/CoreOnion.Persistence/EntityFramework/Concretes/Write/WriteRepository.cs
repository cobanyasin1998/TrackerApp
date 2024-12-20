using CoreBase.Domain;
using CoreBase.Extensions.IQueryable;
using CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;
using CoreOnion.Persistence.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CoreOnion.Persistence.EntityFramework.Concretes.Write;

public class WriteRepository<TEntity, TContext>(TContext Context) : IWriteRepository<TEntity>, IRepository<TEntity>
 where TEntity : BaseEntity
 where TContext : DbContext
{
    public DbSet<TEntity> Table
        => Context.Set<TEntity>();
    public IQueryable<TEntity> Query
        => Table.BaseQuery();

    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task AttachAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task RemoveRangeAsync(IEnumerable<Guid> ids)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdatePartialAsync(Guid id, Expression<Func<TEntity, object>> fields)
    {
        throw new NotImplementedException();
    }

    public Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }
}
