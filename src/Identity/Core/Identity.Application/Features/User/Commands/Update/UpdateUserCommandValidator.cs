using FluentValidation;

namespace Identity.Application.Features.User.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommandRequest>
{
    public UpdateUserCommandValidator()
    {
        // OrganizationEntityId
        RuleFor(c => c.OrganizationEntityId)
            .GreaterThan(0).WithMessage("OrganizationEntityId must be greater than 0.");

        // Username
        RuleFor(c => c.Username)
            .NotNull().WithMessage("Username cannot be null.")
            .NotEmpty().WithMessage("Username cannot be empty.")
            .MaximumLength(30).WithMessage("Username cannot exceed 30 characters.");

        // FirstName
        RuleFor(c => c.FirstName)
            .NotNull().WithMessage("FirstName cannot be null.")
            .NotEmpty().WithMessage("FirstName cannot be empty.")
            .MaximumLength(100).WithMessage("FirstName cannot exceed 100 characters.");

        // SecondName
        RuleFor(c => c.SecondName)
            .MaximumLength(100).WithMessage("SecondName cannot exceed 100 characters.")
            .When(c => !string.IsNullOrEmpty(c.SecondName));

        // LastName
        RuleFor(c => c.LastName)
            .NotNull().WithMessage("LastName cannot be null.")
            .NotEmpty().WithMessage("LastName cannot be empty.")
            .MaximumLength(100).WithMessage("LastName cannot exceed 100 characters.");

        // PhoneNumber
        RuleFor(c => c.PhoneNumber)
            .MaximumLength(15).WithMessage("PhoneNumber cannot exceed 15 characters.")
            .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("PhoneNumber must be a valid E.164 format.")
            .When(c => !string.IsNullOrEmpty(c.PhoneNumber));

        // Bio
        RuleFor(c => c.Bio)
            .MaximumLength(500).WithMessage("Bio cannot exceed 500 characters.")
            .When(c => !string.IsNullOrEmpty(c.Bio));

        // DateOfBirth
        RuleFor(c => c.DateOfBirth)
            .LessThanOrEqualTo(DateTime.Today).WithMessage("DateOfBirth cannot be in the future.");

        // Gender
        RuleFor(c => c.Gender)
            .IsInEnum().WithMessage("Gender must be a valid value.");
    }
}
