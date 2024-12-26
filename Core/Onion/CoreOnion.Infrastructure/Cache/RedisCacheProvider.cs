using CoreBase.Interfaces.CacheInterfaces;
using StackExchange.Redis;

namespace CoreOnion.Infrastructure.Cache;

public class RedisCacheProvider : ICacheProvider
{
    private readonly IDatabase _redisDatabase;

    public RedisCacheProvider(String connectionString)
    {
        ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(connectionString);
        _redisDatabase = redis.GetDatabase();
    }

    public async Task<String?> GetAsync(String key)
    {
        RedisValue value = await _redisDatabase.StringGetAsync(key);
        return value.HasValue ? value.ToString() : null;
    }

    public async Task<IDictionary<String, String?>> GetManyAsync(IEnumerable<String> keys)
    {

        String[]? keyArray = keys.ToArray();
        RedisKey[]? redisKeys = keyArray.Select(key => (RedisKey)key).ToArray();
        RedisValue[]? values = await _redisDatabase.StringGetAsync(redisKeys);

        return keyArray.Zip(values, (key, value) => new { key, value = value.HasValue ? value.ToString() : null })
                       .ToDictionary(x => x.key, x => x.value);

    }

    public async Task SetAsync(String key, String value, TimeSpan expiration)
    {
        await _redisDatabase.StringSetAsync(key, value, expiration);
    }
}
