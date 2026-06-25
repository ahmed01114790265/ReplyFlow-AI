using MediatR;
using Microsoft.EntityFrameworkCore;
using ReplyFlow.Features.Auth.Commands;
using ReplyFlow.Features.Auth.Factory;
using ReplyFlow.Shared.Comman.Authintication;
using ReplyFlow.Shared.Persistence;

namespace ReplyFlow.Features.Auth.Handlers
{
    public sealed class RegisterHandler: IRequestHandler<RegisterCommand, Guid>
    {
        private readonly ReplyFlowDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterHandler(ReplyFlowDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(  RegisterCommand command, CancellationToken cancellationToken)
        {
            var phoneExists = await _context.Users
                                    .AsNoTracking()
                                      .AnyAsync(
                                      user => user.PhoneNumber == command.PhoneNumber,
                                         cancellationToken);

            if (phoneExists)
            {
                throw new InvalidOperationException(
                    "Phone number already exists.");
            }

            var passwordHash = _passwordHasher.HashPassword(command.Password);

            var user = RegisterFactory.CreateUser(command,passwordHash);

            _context.Users.Add(user);

            await _context.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}
