using System.Linq.Expressions;

namespace CoreBase.Interfaces.FilteringInterfaces;

public class CompositeSpecification<T>(IEnumerable<ISpecification<T>> _specifications) : ISpecification<T>
{

    public Expression<Func<T, bool>> ToExpression()
    {
        if (!_specifications.Any())
        {
            return x => true; // Boşsa her şeyi eşleştir
        }

        ParameterExpression? parameter = Expression.Parameter(typeof(T));
        Expression? body = null;

        foreach (ISpecification<T> spec in _specifications)
        {
            InvocationExpression currentExpression = Expression.Invoke(spec.ToExpression(), parameter);

            body = body == null
                ? currentExpression
                : Expression.AndAlso(body, currentExpression);
        }

        return Expression.Lambda<Func<T, bool>>(body ?? Expression.Constant(true), parameter);
    }
}