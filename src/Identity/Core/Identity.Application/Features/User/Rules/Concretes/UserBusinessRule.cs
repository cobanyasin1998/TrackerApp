using CoreBase.Exceptions.CustomExceptions;
using CoreBase.Extensions.Text;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.User.Rules.Abstractions;

namespace Identity.Application.Features.User.Rules.Concretes;

public class UserBusinessRule(IUnitOfWork unitOfWork) : IUserBusinessRule
{
    public  Task IsExistsEmailAddress(string emailAddress)
    {
        bool isExists =  unitOfWork.UserReadRepository.GetWhere(user => user.Email.Equals(emailAddress.RemoveSpacesAndTrim())).Any();
        if (isExists)
        {
            throw new BusinessRuleException("Email address already exists.");
        }
        return Task.CompletedTask;
    }
}
