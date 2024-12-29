using System.Linq.Expressions;

namespace CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

public interface IReadRepository<T> where T : class
{
    IQueryable<T> GetAll(bool tracking = false);
    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = false);
    Task<T?> GetByIdAsync(long id);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate,CancellationToken cancellationToken);
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
    Task<IEnumerable<T>> GetDistinctAsync(Expression<Func<T, object>> selector);
    Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<long> ids);
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
    Task<T?> GetMaxAsync(Expression<Func<T, decimal>> selector);
    Task<T?> GetMinAsync(Expression<Func<T, decimal>> selector);
    Task<decimal> GetSumAsync(Expression<Func<T, decimal>> selector);
    Task<decimal> GetAverageAsync(Expression<Func<T, decimal>> selector);
    Task<IEnumerable<IGrouping<TKey, T>>> GroupByAsync<TKey>(Expression<Func<T, TKey>> keySelector);
    Task<IEnumerable<T>> GetTopAsync(int top, Expression<Func<T, bool>>? predicate = null);
    Task<IEnumerable<T>> GetLatestAsync(int top = 10);
    IQueryable<T> GetByDateRangeAsync(DateTime startDate, DateTime endDate);
    IQueryable<T> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);
    Task<T?> GetLatestByFieldAsync(Expression<Func<T, object>> field);
    Task<int> GetCountByPredicateAsync(Expression<Func<T, bool>> predicate);
    Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);
}
