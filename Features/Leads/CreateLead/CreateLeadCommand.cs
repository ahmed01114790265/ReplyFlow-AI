using MediatR;
using ReplyFlow.Features.Leads.Comman.Enums;

namespace ReplyFlow.Features.Leads.CreateLead
{
    public record CreateLeadCommand(string Name, string Phone, BusinessType BusinessType)
        : IRequest<CreateLeadResult>;
}
