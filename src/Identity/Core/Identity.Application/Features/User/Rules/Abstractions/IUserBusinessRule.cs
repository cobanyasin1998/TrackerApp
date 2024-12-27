using CoreBase.Interfaces.BusinessInterfaces;

namespace Identity.Application.Features.User.Rules.Abstractions;

public interface IUserBusinessRule : IBaseBusinessRule
{
    Task IsExistsEmailAddress(string emailAddress);
    Task IsExistsEmailAddress(string emailAddress, long id);

}
