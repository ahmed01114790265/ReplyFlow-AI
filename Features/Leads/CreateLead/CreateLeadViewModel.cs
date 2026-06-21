using Microsoft.AspNetCore.Mvc.Rendering;
using ReplyFlow.Features.Leads.Comman.Enums;
using System.ComponentModel.DataAnnotations;

namespace ReplyFlow.Features.Leads.CreateLead
{
    public class CreateLeadViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Phone { get; set; } = string.Empty;
        [Required]
        public BusinessType BusinessType { get; set; }
    }
}
