using ReplyFlow.Features.Auth.Commands;
using ReplyFlow.Features.Auth.Entites;
using ReplyFlow.Features.Auth.ViewModels;

namespace ReplyFlow.Features.Auth.Factory
{
    public static class RegisterFactory
    {
        public static User CreateUser(RegisterCommand command, string passwordHash)
        {
            return new User(
                command.PhoneNumber,
                passwordHash);
        }

        public static RegisterCommand CreateCommand(RegisterViewModel model)
        {
            return new RegisterCommand(
                model.PhoneNumber.Trim(),
                model.Password);
        }

       
    }
}
