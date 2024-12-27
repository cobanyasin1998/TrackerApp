namespace Identity.Application.Features.User.Rules.Abstractions;

public interface IUserBusinessRule
{
    Task IsExistsEmailAddress(string emailAddress);
}
