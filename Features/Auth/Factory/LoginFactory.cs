using ReplyFlow.Features.Auth.Commands;
using ReplyFlow.Features.Auth.ViewModels;

namespace ReplyFlow.Features.Auth.Factory
{

    public static class LoginFactory
    {
        public static LoginCommand Create(LoginViewModel model)
        {
            return new LoginCommand(
                model.PhoneNumber,
                model.Password,
                model.RememberMe
            );
        }
    }
}
