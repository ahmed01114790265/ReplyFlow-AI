using MediatR;
using ReplyFlow.Shared.Result_Wrapper;

namespace ReplyFlow.Features.Auth.Commands
{
    public sealed record ForgotPasswordCommand(
    string PhoneNumber
) : IRequest<Result>;
}
