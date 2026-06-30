namespace ReplyFlow.Shared.Exceptions
{
    public sealed class InvalidLoginException : Exception
    {
        public InvalidLoginException()
            : base("Invalid phone number or password.")
        {
        }
    }
}
