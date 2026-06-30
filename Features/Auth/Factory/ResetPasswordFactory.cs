using ReplyFlow.Features.Auth.Commands;
using ReplyFlow.Features.Auth.ViewModels;

namespace ReplyFlow.Features.Auth.Factory
{
    public static class ResetPasswordFactory
    {
        public static ResetPasswordCommand CreateCommand(
            ResetPasswordViewModel model)
        {
            return new ResetPasswordCommand
            (
              model.PhoneNumber,
                 model.ResetCode,
                model.NewPassword
            );
        }
    }
}
