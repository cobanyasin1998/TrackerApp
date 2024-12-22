namespace CoreBase.Interfaces.CacheInterfaces;

public interface ICacheProvider
{
    Task<string?> GetAsync(string key);
    Task SetAsync(string key, string value, TimeSpan expiration);
    Task<IDictionary<string, string?>> GetManyAsync(IEnumerable<string> keys);
}
