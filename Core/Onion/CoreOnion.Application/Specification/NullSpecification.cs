using CoreBase.Interfaces.FilteringInterfaces;
using System.Linq.Expressions;

namespace CoreOnion.Application.Specification;

public class NullSpecification<T> : ISpecification<T> where T : class
{
    public Expression<Func<T, Boolean>> ToExpression()
        => x => true;
}
