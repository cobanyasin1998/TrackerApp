namespace CoreBase.Extensions.IQueryable;

public static class IQueryableBaseExtensions
{
    public static IQueryable<T> BaseQuery<T>(this IQueryable<T> query)
        => query.Where(x => true);

}
