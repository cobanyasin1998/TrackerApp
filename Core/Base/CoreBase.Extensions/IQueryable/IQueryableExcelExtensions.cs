namespace CoreBase.Extensions.IQueryable;

public static class IQueryableExcelExtensions
{
    public static IEnumerable<IQueryable<T>> ChunkBy<T>(this IQueryable<T> query, int size)
    {
        int skip = 0;
        while (query.Skip(skip).Take(size).Any())
        {
            yield return query.Skip(skip).Take(size);
            skip += size;
        }
    }
}
