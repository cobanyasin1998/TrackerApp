using System.Linq.Expressions;

namespace CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

public interface IReadRepository<T> where T : class
{
    IQueryable<T> GetAll();
    Task<T?> GetByIdAsync(Int64 id);
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, Boolean>> predicate);
    Task<Boolean> ExistsAsync(Expression<Func<T, Boolean>> predicate);
    Task<Int32> CountAsync(Expression<Func<T, Boolean>>? predicate = null);

    Task<IEnumerable<T>> GetDistinctAsync(Expression<Func<T, object>> selector);

    // Birden fazla ID ile veri getirme
    Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Int64> ids);

    // İlk eşleşen kaydı getirme
    Task<T?> GetFirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    // Belirli bir kaydın olup olmadığını kontrol etme
    Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

    // Maksimum değeri getirme
    Task<T?> GetMaxAsync(Expression<Func<T, decimal>> selector);

    // Minimum değeri getirme
    Task<T?> GetMinAsync(Expression<Func<T, decimal>> selector);

    // Toplam değer (sum) getirme
    Task<decimal> GetSumAsync(Expression<Func<T, decimal>> selector);

    // Ortalama değeri (average) getirme
    Task<decimal> GetAverageAsync(Expression<Func<T, decimal>> selector);

    // Veriyi gruplama
    Task<IEnumerable<IGrouping<TKey, T>>> GroupByAsync<TKey>(Expression<Func<T, TKey>> keySelector);

    // En üstteki (top) kayıtları getirme
    Task<IEnumerable<T>> GetTopAsync(int top, Expression<Func<T, bool>>? predicate = null);

    // En son eklenen verileri getirme
    Task<IEnumerable<T>> GetLatestAsync(int top = 10);

    // Belirli bir tarih aralığındaki verileri getirme
    IQueryable<T> GetByDateRangeAsync(DateTime startDate, DateTime endDate);

    // İlişkili verilerle veri getirme (Eager Loading)
    IQueryable<T> GetAllWithIncludesAsync(params Expression<Func<T, object>>[] includes);

    // Belirli bir alan üzerinde en son veriyi getirme
    Task<T?> GetLatestByFieldAsync(Expression<Func<T, object>> field);

    // Belirli bir predicate'e göre kayıt sayısını getirme
    Task<int> GetCountByPredicateAsync(Expression<Func<T, bool>> predicate);

    // Dinamik filtreleme ile veri getirme
    Task<IEnumerable<T>> GetByFilterAsync(Expression<Func<T, bool>> filter);

    // Tek bir nesnenin olup olmadığını kontrol etme
    //Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);

    // Sayfalama ve sıralama ile veri getirme
    //Task<IPagedResult<T>> GetPagedAndSortedAsync(
    //    int pageNumber,
    //    int pageSize,
    //    Expression<Func<T, bool>>? predicate = null,
    //    Expression<Func<T, object>> orderBy = null,
    //    bool ascending = true);
}
