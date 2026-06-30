using FluentValidation;
using ReplyFlow.Features.Auth.Commands;

namespace ReplyFlow.Features.Auth.Validations
{
    public  class ForgotPasswordValidator: AbstractValidator<ForgotPasswordCommand>
    {
        public ForgotPasswordValidator()
        {
            RuleFor(x => x.PhoneNumber)
         .Cascade(CascadeMode.Stop)
       .NotEmpty()
         .WithMessage("Phone number is required.")
              .Matches(@"^[+]?[0-9]{8,20}$")
           .WithMessage("Please enter a valid phone number.");
        }
    }
}
