using MediatR;

namespace ReplyFlow.Features.Auth.Commands
{

    public  record RegisterCommand(
        string PhoneNumber,
        string Password
    ) : IRequest<Guid>;
}
