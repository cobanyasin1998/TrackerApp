using System.Linq.Expressions;

namespace CoreBase.Interfaces.RepositoriesInterfaces.EntityFramework;

public interface IReadRepository<T> where T : class
{
    // Tüm veriyi IQueryable olarak döndürür
    IQueryable<T> GetAll();

    // Belirli bir ID'ye göre tek bir kaydı döndürür
    Task<T?> GetByIdAsync(Guid id);

    // Belirli bir filtreye göre veriyi IQueryable olarak döndürür
   // IQueryable<T> Find(Expression<Func<T, bool>> predicate);

    // İlk eşleşen kaydı döndürür
    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    // Belirli bir kaydın olup olmadığını kontrol eder
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);

    // Toplam kayıt sayısını döndürür (isteğe bağlı filtre ile)
    Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);

    // Tek bir kayıt döndürür (birden fazla eşleşme varsa hata fırlatır)
    Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);

    // Sayfalama destekleyen veri getirme
   // Task<IPagedResult<T>> GetPagedAsync(int pageNumber, int pageSize, Expression<Func<T, bool>>? predicate = null);

    // Sıralı veri getirme
    Task<IEnumerable<T>> GetSortedAsync(Expression<Func<T, object>> orderBy, bool ascending = true);

    // Distinct (benzersiz) veriyi getirme
    Task<IEnumerable<T>> GetDistinctAsync(Expression<Func<T, object>> selector);

    // Birden fazla ID ile veri getirme
    Task<IEnumerable<T>> GetByIdsAsync(IEnumerable<Guid> ids);

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
