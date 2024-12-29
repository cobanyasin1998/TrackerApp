using CoreBase.Interfaces.FilteringInterfaces;

namespace CoreBase.Extensions.Specification;

public static class SpecificationExtensions
{
    public static IQueryable<T> ApplySpecification<T>(this IQueryable<T> query, ISpecification<T> specification) where T : class
        => query.Where(specification.ToExpression());
}
