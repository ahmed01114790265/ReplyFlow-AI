using MediatR;
using ReplyFlow.Shared.Result_Wrapper;

namespace ReplyFlow.Features.Auth.Commands
{
    public sealed record VerifyResetCodeCommand(
       string PhoneNumber,
       string ResetCode
   ) : IRequest<Result>;
}
