using CoreBase.Domain;
using CoreBase.Extensions.IQueryable;
using CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;
using CoreOnion.Persistence.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace CoreOnion.Persistence.EntityFramework.Concretes.Read;

public class ReadRepository<TEntity, TContext>(TContext Context) : IReadRepository<TEntity>, IRepository<TEntity>
    where TEntity : BaseEntity
    where TContext : DbContext
{
    public DbSet<TEntity> Table
        => Context.Set<TEntity>();
    public IQueryable<TEntity> Query 
        => Table.BaseQuery();


    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Query.AnyAsync(predicate);
    }
    public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        return predicate is null
           ? await Query.CountAsync()
           : await Query.CountAsync(predicate);
    }
    public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Query.AnyAsync(predicate);
    }
    public IQueryable<TEntity> WhereIf(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().Where(predicate);
    }
    public async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Query.FirstOrDefaultAsync(predicate);
    }//
    public IQueryable<TEntity> GetAll()
    {
        return Query;
    }
    public IQueryable<TEntity> GetAllWithIncludesAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity> query = Query;
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        return query;
    }
    public async Task<decimal> GetAverageAsync(Expression<Func<TEntity, decimal>> selector)
    {
        return await Query.AverageAsync(selector);
    }
    public IQueryable<TEntity> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
    {
        return Context.Set<TEntity>()
            .Where(e => e.CreatedTime >= startDate && e.CreatedTime <= endDate);
    }

    public Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<Guid> ids)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCountByPredicateAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetDistinctAsync(Expression<Func<TEntity, object>> selector)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetLatestAsync(int top = 10)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetLatestByFieldAsync(Expression<Func<TEntity, object>> field)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetMaxAsync(Expression<Func<TEntity, decimal>> selector)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> GetMinAsync(Expression<Func<TEntity, decimal>> selector)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetSortedAsync(Expression<Func<TEntity, object>> orderBy, bool ascending = true)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetSumAsync(Expression<Func<TEntity, decimal>> selector)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetTopAsync(int top, Expression<Func<TEntity, bool>>? predicate = null)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<IGrouping<TKey, TEntity>>> GroupByAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }
}
