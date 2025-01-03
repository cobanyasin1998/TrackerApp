using FluentValidation;

namespace Identity.Application.Features.Organization.Commands.Create;

public class CreateOrganizationCommandValidator: AbstractValidator<CreateOrganizationCommandRequest>
{
    public CreateOrganizationCommandValidator()
    {
        // Name is required and must have a minimum length
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters long.");

        // Code is required and must have a specific format or length
        RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Code is required.")
            .Matches("^[A-Za-z0-9]+$").WithMessage("Code must only contain alphanumeric characters.")
            .Length(2, 10).WithMessage("Code must be between 2 and 10 characters long.");

        // Description is optional but if provided, it should not exceed a certain length
        RuleFor(x => x.Description)
            .MaximumLength(250).WithMessage("Description must not exceed 250 characters.");

        // ParentOrganizationId is optional, but it should be positive if provided
        RuleFor(x => x.ParentOrganizationId)
            .GreaterThan(0).When(x => x.ParentOrganizationId.HasValue)
            .WithMessage("ParentOrganizationId must be greater than 0 if provided.");
    }
}