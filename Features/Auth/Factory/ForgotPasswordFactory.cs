using ReplyFlow.Features.Auth.Commands;
using ReplyFlow.Features.Auth.ViewModels;

namespace ReplyFlow.Features.Auth.Factory
{
    public static class ForgotPasswordFactory
    {
        public static ForgotPasswordCommand CreateCommand(ForgotPasswordViewModel model)
        {
            return new ForgotPasswordCommand( model.PhoneNumber);
        }
    }
}
