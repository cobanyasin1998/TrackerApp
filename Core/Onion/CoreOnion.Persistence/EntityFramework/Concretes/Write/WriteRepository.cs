using CoreBase.Domain;
using CoreBase.Extensions.IQueryable;
using CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;
using CoreOnion.Persistence.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Reflection;

namespace CoreOnion.Persistence.EntityFramework.Concretes.Write;
public class WriteRepository<TEntity, TContext>(TContext Context) : IWriteRepository<TEntity>, IRepository<TEntity>
 where TEntity : BaseEntity
 where TContext : DbContext
{
    public DbSet<TEntity> Table 
        => Context.Set<TEntity>();

    public async Task AddAsync(TEntity entity)
    {
        await Table.AddAsync(entity);
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities)
    {
        await Table.AddRangeAsync(entities);
    }

    public Task AttachAsync(TEntity entity)
    {
        Table.Attach(entity);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(TEntity entity)
    {
        entity.Status = CoreBase.Enums.Entities.EEntityStatus.Inactive;
        return Task.CompletedTask;
    }

    public async Task DeleteByIdAsync(long id)
    {
        TEntity? entity = await Table.FindAsync(id);
        if (entity != null)
        {
            Table.Remove(entity);
        }
    }

    public Task DeleteRangeAsync(IEnumerable<TEntity> entities)
    {
        Table.RemoveRange(entities);
        return Task.CompletedTask;
    }

    public async Task RemoveRangeAsync(IEnumerable<long> ids)
    {
        List<TEntity>? entities = await Table.Where(e => ids.Contains(e.Id)).ToListAsync();
        Table.RemoveRange(entities);
    }

    public async Task SaveAsync()
    {
        await Context.SaveChangesAsync();
    }

    public Task UpdateAsync(TEntity entity)
    {
        Table.Update(entity);
        return Task.CompletedTask;
    }

    public Task UpdatePartialAsync(long id, Expression<Func<TEntity, object>> fields)
    {
        TEntity? entity = Table.Find(id) ?? throw new InvalidOperationException("Entity not found.");
        EntityEntry<TEntity>? entry = Context.Entry(entity);
        if (fields.Body is NewExpression newExpression)
        {
            foreach (MemberInfo member in newExpression.Members)
            {
                entry.Property(member.Name).IsModified = true;
            }
        }
        else
        {
            throw new InvalidOperationException("Invalid fields expression. Use a New expression with property names.");
        }

        return Task.CompletedTask;
    }

    public Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        Table.UpdateRange(entities);
        return Task.CompletedTask;
    }
}
