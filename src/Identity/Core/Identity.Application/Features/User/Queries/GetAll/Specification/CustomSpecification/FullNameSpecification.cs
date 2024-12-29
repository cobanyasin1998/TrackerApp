using CoreBase.Identity.Entities.Base;
using CoreBase.Interfaces.FilteringInterfaces;
using CoreOnion.Application.Specification;
using System.Linq.Expressions;

namespace Identity.Application.Features.User.Queries.GetAll.Specification.CustomSpecification;

public class FullNameSpecification(string? _fullName) : ISpecification<UserEntity>
{
    public Expression<Func<UserEntity, bool>> ToExpression()
    {
        if (string.IsNullOrWhiteSpace(_fullName))
            return new NullSpecification<UserEntity>().ToExpression();
        return x => (x.FirstName + " " + x.LastName).Contains(_fullName);
    }
}