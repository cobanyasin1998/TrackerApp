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
    public DbSet<TEntity> Table => Context.Set<TEntity>();
    public IQueryable<TEntity> Query => Table.BaseQuery();

    public Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null)
        => predicate == null ? Query.CountAsync() : Query.CountAsync(predicate);

    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        => Query.AnyAsync(predicate);

    public Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
        => Query.FirstOrDefaultAsync(predicate,cancellationToken);

    public IQueryable<TEntity> GetAll(bool tracking = false)
        => tracking ? Query : Query.AsNoTracking();

    public IQueryable<TEntity> GetAllWithIncludesAsync(params Expression<Func<TEntity, object>>[] includes)
    {
        IQueryable<TEntity>? query = Query.AsQueryable();
        foreach (Expression<Func<TEntity, object>> include in includes)
        {
            query = query.Include(include);
        }
        return query;
    }

    public Task<decimal> GetAverageAsync(Expression<Func<TEntity, decimal>> selector)
        => Query.AverageAsync(selector);

    public IQueryable<TEntity> GetByDateRangeAsync(DateTime startDate, DateTime endDate)
        => Query.Where(x => x.CreatedTime >= startDate && x.CreatedTime <= endDate);

    public async Task<IEnumerable<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> filter)
        => await Query.Where(filter).ToListAsync();

    public Task<TEntity?> GetByIdAsync(long id)
        => Query.FirstOrDefaultAsync(e => e.Id == id);

    public async Task<IEnumerable<TEntity>> GetByIdsAsync(IEnumerable<long> ids)
        => await Query.Where(e => ids.Contains(e.Id)).ToListAsync();

    public Task<int> GetCountByPredicateAsync(Expression<Func<TEntity, bool>> predicate)
        => Query.CountAsync(predicate);

    public async Task<IEnumerable<TEntity>> GetDistinctAsync(Expression<Func<TEntity, object>> selector)
        => await Query.Select(selector).Distinct().Cast<TEntity>().ToListAsync();

    public Task<TEntity?> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        => Query.FirstOrDefaultAsync(predicate);

    public async Task<IEnumerable<TEntity>> GetLatestAsync(int top = 10)
        => await Query.OrderByDescending(e => e.CreatedTime).Take(top).ToListAsync();

    public Task<TEntity?> GetLatestByFieldAsync(Expression<Func<TEntity, object>> field)
        => Query.OrderByDescending(field).FirstOrDefaultAsync();

    public Task<TEntity?> GetMaxAsync(Expression<Func<TEntity, decimal>> selector)
        => Query.OrderByDescending(selector).FirstOrDefaultAsync();

    public Task<TEntity?> GetMinAsync(Expression<Func<TEntity, decimal>> selector)
        => Query.OrderBy(selector).FirstOrDefaultAsync();

    public Task<decimal> GetSumAsync(Expression<Func<TEntity, decimal>> selector)
        => Query.SumAsync(selector);

    public async Task<IEnumerable<TEntity>> GetTopAsync(int top, Expression<Func<TEntity, bool>>? predicate = null)
    {
        IQueryable<TEntity>? query = predicate == null ? Query : Query.Where(predicate);
        return await query.Take(top).ToListAsync();
    }

    public IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> predicate, bool tracking = false)
        => tracking ? Query.Where(predicate) : Query.Where(predicate).AsNoTracking();

    public async Task<IEnumerable<IGrouping<TKey, TEntity>>> GroupByAsync<TKey>(Expression<Func<TEntity, TKey>> keySelector)
        => await Query.GroupBy(keySelector).ToListAsync();
}
