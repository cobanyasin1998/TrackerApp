using CoreBase.Identity.Entities.Base;
using CoreBase.Interfaces.FilteringInterfaces;
using CoreOnion.Application.Specification;
using Identity.Application.Features.User.Queries.GetAll.Specification.CustomSpecification;

namespace Identity.Application.Features.User.Queries.GetAll.Specification.Factory;

public static class UserSpecificationFactory
{
    public static ISpecification<UserEntity> Create(UserGetAllFiltersDto? filters)
    {
        if (filters == null) return new NullSpecification<UserEntity>();
        List<ISpecification<UserEntity>> specifications = [];

        if (!string.IsNullOrWhiteSpace(filters?.FullName))
        {
            specifications.Add(new FullNameSpecification(filters.FullName));
        }

        if (!string.IsNullOrWhiteSpace(filters?.EmailorUsername))
        {
            //specifications.Add(new EmailOrUsernameSpecification(filters.EmailorUsername));
        }

        return specifications.Any()
            ? new CompositeSpecification<UserEntity>(specifications)
            : new NullSpecification<UserEntity>();
    }
}
