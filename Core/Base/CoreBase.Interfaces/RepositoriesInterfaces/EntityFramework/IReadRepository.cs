using System.Linq.Expressions;

namespace CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

public interface IReadRepository<T> where T : class
{
    // Get all records with optional tracking
    IQueryable<T> GetAll(bool tracking = false);

    // Get records matching a predicate with optional tracking
    IQueryable<T> GetWhere(Expression<Func<T, bool>> predicate, bool tracking = false);

    // Get a record by ID
    Task<T?> GetByIdAsync(long id);

    // Get the first record matching a predicate
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    // Check if any record matches a predicate
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

    // Count records matching a predicate (or all if null)
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    // Get distinct records based on a selector
    Task<IEnumerable<T>> GetDistinctAsync(Expression<Func<T, object>> selector);

    // Get records by multiple IDs
    Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<long> ids);

    // Get the first record matching a predicate
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    // Get the maximum value based on a selector
    Task<T?> GetMaxAsync(Expression<Func<T, decimal>> selector);

    // Get the minimum value based on a selector
    Task<T?> GetMinAsync(Expression<Func<T, decimal>> selector);

    // Get the sum of values based on a selector
    Task<decimal> GetSumAsync(Expression<Func<T, decimal>> selector);

    // Get the average of values based on a selector
    Task<decimal> GetAverageAsync(Expression<Func<T, decimal>> selector);

    // Group records by a key selector
    Task<IEnumerable<IGrouping<TKey, T>>> GroupByAsync<TKey>(Expression<Func<T, TKey>> keySelector);

    // Get the top N records optionally filtered by a predicate
    Task<IEnumerable<T>> GetTopAsync(int top, Expression<Func<T, bool>>? predicate = null);

    // Get the most recently added records
    Task<IEnumerable<T>> GetLatestAsync(int top = 10);

    // Get records within a date range
    IQueryable<T> GetByDateRangeAsync(DateTime startDate, DateTime endDate);

    // Include related data (eager loading)
    IQueryable<T> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);

    // Get the latest record based on a specific field
    Task<T?> GetLatestByFieldAsync(Expression<Func<T, object>> field);

    // Count records by a specific predicate
    Task<int> GetCountByPredicateAsync(Expression<Func<T, bool>> predicate);

    // Get records matching a dynamic filter
    Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);

    //// Paginated and sorted data retrieval
    //Task<IPagedResult<T>> GetPagedAndSortedAsync(
    //    int pageNumber,
    //    int pageSize,
    //    Expression<Func<T, bool>>? predicate = null,
    //    Expression<Func<T, object>>? orderBy = null,
    //    bool ascending = true,
    //    bool tracking = false,
    //    params Expression<Func<T, object>>[] includes);
}
