using MediatR;
using Microsoft.EntityFrameworkCore;
using ReplyFlow.Features.Auth.Commands;
using ReplyFlow.Shared.Persistence;
using ReplyFlow.Shared.Result_Wrapper;

namespace ReplyFlow.Features.Auth.Handlers
{
    public  class VerifyResetCodeHandler : IRequestHandler<VerifyResetCodeCommand, Result>
    {
        private readonly ReplyFlowDbContext _context;

        public VerifyResetCodeHandler(ReplyFlowDbContext context)
        {
            _context = context;
        }

        public async Task<Result> Handle(VerifyResetCodeCommand command, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .SingleOrDefaultAsync(
                    x => x.PhoneNumber == command.PhoneNumber,
                    cancellationToken);

            if (user is null)
            {
                return Result.Failure("Invalid phone number");
            }

            if (!user.IsResetCodeValid(command.ResetCode))
            {
                return Result.Failure("Invalid or expired code");
            }

            return Result.Success();
        }
    }
}
