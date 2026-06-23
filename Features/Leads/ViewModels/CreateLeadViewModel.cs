using ReplyFlow.Features.Leads.Enums;
using System.ComponentModel.DataAnnotations;

namespace ReplyFlow.Features.Leads.ViewModels
{
    public class CreateLeadViewModel
    {
        [Required]
        [MaxLength(200)]

        public string Name { get; set; } = string.Empty;
        [Required]
        [RegularExpression(@"^[0-9+\s]{10,15}$")]

        public string Phone { get; set; } = string.Empty;
        [Required]
        public BusinessType BusinessType { get; set; }
    }
}
