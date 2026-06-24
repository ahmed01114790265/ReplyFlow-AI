using ReplyFlow.Features.Leads.Enums;

namespace ReplyFlow.Features.Leads.Entities
{
    public class Lead
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get;  set; } = string.Empty;

        public BusinessType BusinessType { get;  set; }
        public DateTime CreatedAt { get;  set; } = DateTime.UtcNow;
    }
}
