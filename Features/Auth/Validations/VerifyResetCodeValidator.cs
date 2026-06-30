using FluentValidation;
using ReplyFlow.Features.Auth.Commands;

namespace ReplyFlow.Features.Auth.Validations
{
    public sealed class VerifyResetCodeValidator
    : AbstractValidator<VerifyResetCodeCommand>
    {
        public VerifyResetCodeValidator()
        {
            RuleFor(x => x.PhoneNumber)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Phone number is required.")
                .Matches(@"^[+]?[0-9]{8,20}$")
                .WithMessage("Please enter a valid phone number.");

            RuleFor(x => x.ResetCode)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Reset code is required.")
                .Length(6)
                .WithMessage("Reset code must be 6 digits.")
                .Matches(@"^\d{6}$")
                .WithMessage("Reset code must contain only digits.");
        }
    }
}
