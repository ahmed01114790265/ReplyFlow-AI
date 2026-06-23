using ReplyFlow.Features.Leads.Enums;
using MediatR;

namespace ReplyFlow.Features.Leads.Commands
{

    public class CreateLeadCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public BusinessType BusinessType { get; set; }
    }
}
