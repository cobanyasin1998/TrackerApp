using FluentValidation;
using Identity.Application.Features.User.Commands.Update;

namespace Identity.Application.Features.Organization.Commands.Update;

public class UpdateOrganizationCommandValidator : AbstractValidator<UpdateOrganizationCommandRequest>
{
    public UpdateOrganizationCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required.")
            .GreaterThan(0).WithMessage("Id must be greater than 0.");
    }
}
