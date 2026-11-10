using FluentValidation;
using job_helper_api.Features.Auth.DTOs;

namespace job_helper_api.Features.Auth.Validators;

public class UserRegisterValidator : AbstractValidator<UserRegisterRequest>
{
    public UserRegisterValidator()
    {
        // Email Validation
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        // Password Validation
        RuleFor(x => x.Password)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
                .WithMessage("Password is required.")
            .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(128)
                .WithMessage("Password cannot exceed 128 characters.");

        // Confirm Password
        RuleFor(x => x.ConfirmPassword)
            .Cascade(CascadeMode.Stop)
            .NotEmpty()
                .WithMessage("Please confirm password.")
            .Equal(x => x.Password)
                .WithMessage("Passwords do not match.");
    }
}