using System.ComponentModel.DataAnnotations;

namespace ReplyFlow.Features.Auth.ViewModels
{
    public sealed class VerifyResetCodeViewModel
    {
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Reset Code")]
        public string ResetCode { get; set; } = string.Empty;
    }
}
