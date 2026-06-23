using ReplyFlow.Features.Leads.Commands;
using ReplyFlow.Features.Leads.Entities;
using ReplyFlow.Features.Leads.ViewModels;

namespace ReplyFlow.Features.Leads.Factory
{
    public static class LeadFactory
    {
        public static Lead CreateLead(CreateLeadCommand request)
        {
            return new Lead
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Phone = request.Phone,
                BusinessType = request.BusinessType,
                CreatedAt = DateTime.UtcNow
            };
        }

        public static CreateLeadCommand CreateCommandLead(CreateLeadViewModel model)
        {
            return new CreateLeadCommand
            {
                Name = model.Name,
                Phone = model.Phone,
                BusinessType = model.BusinessType
            };
        }
    }
}
