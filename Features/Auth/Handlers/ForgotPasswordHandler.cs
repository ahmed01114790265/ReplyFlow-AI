using MediatR;
using Microsoft.EntityFrameworkCore;
using ReplyFlow.Features.Auth.Commands;
using ReplyFlow.Shared.Persistence;
using ReplyFlow.Shared.Result_Wrapper;

namespace ReplyFlow.Features.Auth.Handlers
{
    public sealed class ForgotPasswordHandler: IRequestHandler<ForgotPasswordCommand, Result>
    {
        private readonly ReplyFlowDbContext _context;

        public ForgotPasswordHandler( ReplyFlowDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle( ForgotPasswordCommand command, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                      .SingleOrDefaultAsync(
                        x => x.PhoneNumber == command.PhoneNumber,cancellationToken);
            if (user is null)
            {
                return Result.Success();
            }

            var resetCode = Random.Shared
            .Next(100000, 999999)
            .ToString();

            user.SetResetCode(
                resetCode,
                DateTime.UtcNow.AddMinutes(10));

            await _context.SaveChangesAsync(cancellationToken);
            return Result.Success();
        }
    }
}
