using CoreBase.Extensions.Text;
using CoreBase.Helpers.Compression;
using CoreBase.Interfaces.CacheInterfaces;
using CoreBase.Interfaces.GlobalizationInterfaces;

namespace CoreOnion.Infrastructure.Globalization;

public class LanguageService(ICacheProvider _cacheProvider) : ILanguageService
{
    public async Task<string> GetValueAsync(String key, String lang)
    {
        String cacheKey = $"{lang}:{key}";

        String? cachedValue = await _cacheProvider.GetAsync(cacheKey);
        if (!String.IsNullOrWhiteSpace(cachedValue))
            return cachedValue;

        return key.AddSpacesBeforeUppercase();
    }

    public async Task<IDictionary<string, string>> GetValuesAsync(IEnumerable<String> keys, String lang)
    {
        Dictionary<String, String> result = [];

        foreach (String key in keys)
            result[key] = await GetValueAsync(key,lang);
        
        return result;
    }

}
