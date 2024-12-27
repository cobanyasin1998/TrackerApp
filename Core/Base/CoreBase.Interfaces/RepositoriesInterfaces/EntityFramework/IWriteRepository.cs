using System.Linq.Expressions;

namespace CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

public interface IWriteRepository<T> where T : class
{
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
    Task DeleteAsync(T entity);
    Task DeleteByIdAsync(Int64 id);
    Task DeleteRangeAsync(IEnumerable<T> entities);
    Task AttachAsync(T entity);
    Task RemoveRangeAsync(IEnumerable<Int64> ids);
    Task UpdatePartialAsync(Int64 id, Expression<Func<T, Object>> fields);
}

