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

        var parameter = Expression.Parameter(typeof(T));
        Expression? body = null;

        foreach (var spec in _specifications)
        {
            var currentExpression = Expression.Invoke(spec.ToExpression(), parameter);

            body = body == null
                ? currentExpression
                : Expression.AndAlso(body, currentExpression);
        }

        return Expression.Lambda<Func<T, bool>>(body ?? Expression.Constant(true), parameter);
    }
}