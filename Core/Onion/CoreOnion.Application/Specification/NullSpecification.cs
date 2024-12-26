using CoreBase.Interfaces.FilteringInterfaces;
using System.Linq.Expressions;

namespace CoreOnion.Application.Specification;

public class NullSpecification<T> : ISpecification<T>
{
    public Expression<Func<T, Boolean>> ToExpression()
        => x => true;
}
