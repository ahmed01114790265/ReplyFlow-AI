using MediatR;

namespace ReplyFlow.Features.Auth.Commands
{
    public record LoginCommand(
     string PhoneNumber,
     string Password,
     bool RememberMe
 ) : IRequest<Guid>;
}
