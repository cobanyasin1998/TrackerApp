using CoreBase.Interfaces.CacheInterfaces;

namespace CoreOnion.Infrastructure.Cache;

public class CouchbaseCacheProvider : ICacheProvider
{
    public Task<string?> GetAsync(string key)
    {
        throw new NotImplementedException();
    }

    public Task<IDictionary<string, string?>> GetManyAsync(IEnumerable<string> keys)
    {
        throw new NotImplementedException();
    }

    public Task SetAsync(string key, string value, TimeSpan expiration)
    {
        throw new NotImplementedException();
    }
}
