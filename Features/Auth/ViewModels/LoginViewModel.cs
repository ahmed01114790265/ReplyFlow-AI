namespace ReplyFlow.Features.Auth.ViewModels
{
    public  class LoginViewModel
    {
        public string PhoneNumber { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public bool RememberMe { get; set; }
    }
}
