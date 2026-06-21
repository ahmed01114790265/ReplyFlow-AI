using MediatR;
using ReplyFlow.Features.Leads.Entity;
using ReplyFlow.Shared.Persistence;
using Microsoft.EntityFrameworkCore;

namespace ReplyFlow.Features.Leads.CreateLead
{
    public record CreateLeadResult(Guid? LeadId, bool IsDuplicate);
    public class CreateLeadHandler : IRequestHandler<CreateLeadCommand, CreateLeadResult>
    {
        private readonly ReplyFlowDbContext _db;

        public CreateLeadHandler(ReplyFlowDbContext db)
        {
            _db = db;
        }

        public async Task<CreateLeadResult> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
        {
            var existingId = await _db.Leads
                .AsNoTracking()
                 .Where(x => x.Phone == request.Phone)
                   .Select(x => (Guid?)x.Id)
                    .FirstOrDefaultAsync(cancellationToken);

            if (existingId.HasValue)
                return new CreateLeadResult(existingId.Value, true);
            var lead = new Lead
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Phone = request.Phone,
                BusinessType = request.BusinessType,
                CreatedAt = DateTime.UtcNow
            };

            _db.Leads.Add(lead);
            await _db.SaveChangesAsync(cancellationToken);

            return  new CreateLeadResult(lead.Id, false);
        }
    }
}
