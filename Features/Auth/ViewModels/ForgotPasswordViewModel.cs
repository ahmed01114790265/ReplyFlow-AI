using System.ComponentModel.DataAnnotations;

namespace ReplyFlow.Features.Auth.ViewModels
{

    public sealed class ForgotPasswordViewModel
    {
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
