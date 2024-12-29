using CoreBase.Dto.IQueryable.Paged;

namespace CoreBase.Extensions.IQueryable;


public static class IQueryablePagingExtensions
{
    private const int DefaultPageSize = 50; 
    private const int DefaultPageNumber = 1;
    private const int MaxPageSize = 1000;
    private const int MaxPageNumber = 1000; 

    public static IQueryable<T> ApplyPaging<T>(
        this IQueryable<T> query,
        Paging? paging)
    {
        int pageSize = Math.Clamp(paging?.Size ?? DefaultPageSize, 1, MaxPageSize);
        int pageNumber = Math.Clamp(paging?.Page ?? DefaultPageNumber, 1, MaxPageNumber);

        return query
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
    }
}
