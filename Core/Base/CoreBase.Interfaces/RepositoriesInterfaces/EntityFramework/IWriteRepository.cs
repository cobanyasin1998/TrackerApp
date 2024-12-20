using System.Linq.Expressions;

namespace CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

public interface IWriteRepository<T> where T : class
{
    // Yeni bir öğe ekler
    Task AddAsync(T entity);

    // Birden fazla öğe ekler
    Task AddRangeAsync(IEnumerable<T> entities);

    // Mevcut bir öğeyi günceller
    Task UpdateAsync(T entity);

    // Birden fazla öğeyi günceller
    Task UpdateRangeAsync(IEnumerable<T> entities);

    // Bir öğeyi siler
    Task DeleteAsync(T entity);

    // ID'ye göre bir öğeyi siler
    Task DeleteByIdAsync(Guid id);

    // Birden fazla öğeyi siler
    Task DeleteRangeAsync(IEnumerable<T> entities);

    // Değişiklikleri kaydeder
    Task SaveAsync();

    // Veriyi bağlar (disconnected nesneleri bağlama)
    Task AttachAsync(T entity);

    // Birden fazla öğeyi ID'ye göre siler
    Task RemoveRangeAsync(IEnumerable<Guid> ids);

    // Kısmi güncelleme yapar
    Task UpdatePartialAsync(Guid id, Expression<Func<T, object>> fields);
}

