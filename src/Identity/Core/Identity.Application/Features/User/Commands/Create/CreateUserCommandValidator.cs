using FluentValidation;
using Identity.Application.Features.User.Constants;

namespace Identity.Application.Features.User.Commands.Create;


public class CreateUserCommandValidator : AbstractValidator<CreateUserCommandRequest>
{
    public CreateUserCommandValidator()
    { 

        RuleFor(c => c.OrganizationEntityId)
            .GreaterThan(0).WithMessage("OrganizationEntityId must be greater than 0.");

        RuleFor(c => c.Email)
                .NotNull().WithMessage(UserConstants.EmailRequired)
                .NotEmpty().WithMessage(UserConstants.EmailRequired)
                .EmailAddress().WithMessage(UserConstants.EmailInvalid)
                .MaximumLength(255).WithMessage(UserConstants.EmailTooLong);
    }
}