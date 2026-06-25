using FluentValidation;
using ReplyFlow.Features.Auth.Commands;

namespace ReplyFlow.Features.Auth.Validations
{
  
    public  class RegisterValidator
        : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.PhoneNumber)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^\+[1-9]\d{7,14}$")
            .WithMessage("Phone number must be in E.164 format.");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password is required.")

                .MinimumLength(8)
                .WithMessage("Password must be at least 8 characters.")

                .MaximumLength(100)
                .WithMessage("Password must not exceed 100 characters.")

                .Matches("[a-z]")
                .WithMessage("Password must contain at least one lowercase letter.")

                .Matches("[A-Z]")
                .WithMessage("Password must contain at least one uppercase letter.")

                .Matches("[0-9]")
                .WithMessage("Password must contain at least one number.");
        }
    }
}
