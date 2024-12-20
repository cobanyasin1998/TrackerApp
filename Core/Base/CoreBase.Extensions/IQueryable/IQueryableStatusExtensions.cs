using CoreBase.Enums.Entities;
using CoreBase.Interfaces.EntityInterfaces;

namespace CoreBase.Extensions.IQueryable;

public static class IQueryableStatusExtensions
{
    public static IQueryable<T> OnlyActive<T>(this IQueryable<T> query) where T : IStatus
      => query.Where(x => x.Status  == EEntityStatus.Active);

    public static IQueryable<T> OnlyDeleted<T>(this IQueryable<T> query) where T : IStatus
        => query.Where(x => x.Status == EEntityStatus.Active);
}
