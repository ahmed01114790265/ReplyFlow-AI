using FluentValidation;
using ReplyFlow.Features.Leads.Commands;

namespace ReplyFlow.Features.Leads.Validations
{
    public class CreateLeadValidator : AbstractValidator<CreateLeadCommand>
    {
        public CreateLeadValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Phone)
                .NotEmpty()
               .Matches(@"^[0-9+\s]{10,15}$")
                .WithMessage("Invalid phone number");
            RuleFor(x => x.BusinessType).IsInEnum();
        }
    }
}
