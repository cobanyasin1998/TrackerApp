namespace CoreBase.Interfaces.GlobalizationInterfaces;

public interface ILanguageService
{
    Task<String> GetValueAsync(String key, String lang);
    Task<IDictionary<String, String>> GetValuesAsync(IEnumerable<String> keys, String lang);
}
