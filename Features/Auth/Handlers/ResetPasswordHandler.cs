using MediatR;
using Microsoft.EntityFrameworkCore;
using ReplyFlow.Features.Auth.Commands;
using ReplyFlow.Shared.Comman.Authintication;
using ReplyFlow.Shared.Persistence;
using ReplyFlow.Shared.Result_Wrapper;

namespace ReplyFlow.Features.Auth.Handlers
{
    public sealed class ResetPasswordHandler : IRequestHandler<ResetPasswordCommand, Result>
    {
        private readonly ReplyFlowDbContext _context;
        private readonly IPasswordHasher _passwordHasher;

        public ResetPasswordHandler(
            ReplyFlowDbContext context,
            IPasswordHasher passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<Result> Handle(ResetPasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(
                    x => x.PhoneNumber == command.PhoneNumber,
                    cancellationToken);

            if (user is null)
            {
                return Result.Failure("Invalid request");
            }

            if (!user.IsResetCodeValid(command.ResetCode))
            {
                return Result.Failure("Invalid or expired code");
            }

            var passwordHash = _passwordHasher.HashPassword(command.NewPassword);

            user.ChangePassword(passwordHash);


            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    }
}
