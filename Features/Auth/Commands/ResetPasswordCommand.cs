using MediatR;
using ReplyFlow.Shared.Result_Wrapper;

namespace ReplyFlow.Features.Auth.Commands
{
    public sealed record ResetPasswordCommand(
    string PhoneNumber,
    string ResetCode,
    string NewPassword
) : IRequest<Result>;
}
