using FluentValidation;

namespace ReplyFlow.Features.Leads.CreateLead
{
    public class CreateLeadValidator : AbstractValidator<CreateLeadCommand>
    {
        public CreateLeadValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(150);

            RuleFor(x => x.Phone)
                .NotEmpty()
               .Matches(@"^[0-9+\s]{10,15}$")
                .WithMessage("Invalid phone number");

            RuleFor(x => x.BusinessType)
                .IsInEnum();
        }
    }
}
