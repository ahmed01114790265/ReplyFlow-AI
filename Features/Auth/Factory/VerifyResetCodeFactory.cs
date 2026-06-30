using ReplyFlow.Features.Auth.Commands;
using ReplyFlow.Features.Auth.ViewModels;

namespace ReplyFlow.Features.Auth.Factory
{
    public static class VerifyResetCodeFactory
    {
        public static VerifyResetCodeCommand CreateCommand(  VerifyResetCodeViewModel model)
        {
            return new VerifyResetCodeCommand
           (
                model.PhoneNumber,
                 model.ResetCode
            );
        }
    }
}
