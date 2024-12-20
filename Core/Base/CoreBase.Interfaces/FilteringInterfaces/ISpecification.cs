using System.Linq.Expressions;

namespace CoreBase.Interfaces.FilteringInterfaces;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> ToExpression();
}
