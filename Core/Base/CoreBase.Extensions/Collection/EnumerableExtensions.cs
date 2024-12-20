namespace CoreBase.Extensions.Collection;


public static class EnumerableExtensions
{
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        => source is not null || !source.Any();
}
