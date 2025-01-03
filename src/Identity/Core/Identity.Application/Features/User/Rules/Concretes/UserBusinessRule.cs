using CoreBase.Exceptions.CustomExceptions;
using CoreBase.Extensions.Text;
using Identity.Application.Abstractions.UnitOfWork;
using Identity.Application.Features.User.Rules.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Identity.Application.Features.User.Rules.Concretes;

public class UserBusinessRule(IUnitOfWork _unitOfWork) : IUserBusinessRule
{
    public async Task IsExistsEmailAddress(string emailAddress, CancellationToken cancellationToken = default)
    {
        bool isExists = await _unitOfWork.UserReadRepository.GetWhere(user => user.Email.Equals(emailAddress.RemoveSpacesAndTrim())).AnyAsync(cancellationToken);
        if (isExists)
            throw new BusinessRuleException("Email address already exists.");
    }

    public async Task IsExistsEmailAddress(string emailAddress, long id, CancellationToken cancellationToken = default)
    {
        bool isExists = await _unitOfWork.UserReadRepository.GetWhere(user => user.Id == id && user.Email.Equals(emailAddress.RemoveSpacesAndTrim())).AnyAsync(cancellationToken);
        if (isExists)
            throw new BusinessRuleException("Email address already exists.");
    }
}
