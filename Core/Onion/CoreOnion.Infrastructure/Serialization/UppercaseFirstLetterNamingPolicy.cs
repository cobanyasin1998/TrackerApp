using System.Text.Json;

namespace CoreOnion.Infrastructure.Serialization;

public class UppercaseFirstLetterNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        return char.ToUpperInvariant(name[0]) + name[1..];
    }
}
