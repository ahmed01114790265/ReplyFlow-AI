using ReplyFlow.Features.Leads.Commands;
using ReplyFlow.Features.Leads.Factory;
using ReplyFlow.Shared.Persistence;
using MediatR;

namespace ReplyFlow.Features.Leads.Handlers
{

    public class CreateLeadHandler: IRequestHandler<CreateLeadCommand, Guid>
    {
        private readonly ReplyFlowDbContext _db;

        public CreateLeadHandler(ReplyFlowDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var lead = LeadFactory.CreateLead(request);

            _db.Leads.Add(lead);

            await _db.SaveChangesAsync(cancellationToken);

            return lead.Id;
        }
    }
}
