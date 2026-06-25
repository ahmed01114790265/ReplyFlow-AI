namespace ReplyFlow.Shared.Comman.Authintication
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);

        bool VerifyPassword(
            string password,
            string passwordHash);
    }
}
