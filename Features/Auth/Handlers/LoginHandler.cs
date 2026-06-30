using MediatR;
using Microsoft.EntityFrameworkCore;
using ReplyFlow.Features.Auth.Commands;
using ReplyFlow.Shared.Comman.Authintication;
using ReplyFlow.Shared.Exceptions;
using ReplyFlow.Shared.Persistence;

namespace ReplyFlow.Features.Auth.Handlers
{
    public sealed class LoginHandler : IRequestHandler<LoginCommand, Guid>
    {
        private readonly ReplyFlowDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public LoginHandler(
            ReplyFlowDbContext context,
            IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle( LoginCommand command,CancellationToken cancellationToken)
        {
            var user = await _context.Users
                   .AsNoTracking()
                    .SingleOrDefaultAsync(x => x.PhoneNumber == command.PhoneNumber,cancellationToken);

            if (user is null)
            {
                throw new InvalidLoginException();
            }

            if (!_passwordHasher.VerifyPassword(command.Password, user.PasswordHash))
            {
                throw new InvalidLoginException();
            }
            return user.Id;
        }
    }
}
