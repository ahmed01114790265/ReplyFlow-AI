using ReplyFlow.Features.Auth.Enums;

namespace ReplyFlow.Features.Auth.Entites
{
    public class User
    {
        public Guid Id { get; private set; }

        public string PhoneNumber { get; private set; } = string.Empty;

        public string PasswordHash { get; private set; } = string.Empty;

        public UserRole Role { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreatedAtUtc { get; private set; }

        public DateTime? LastLoginAtUtc { get; private set; }

        public string? PasswordResetToken { get; private set; }

        public DateTime? PasswordResetTokenExpiryUtc { get; private set; }

        private User() { }

        public User(string phoneNumber, string passwordHash)
        {
            Id = Guid.NewGuid();
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            Role = UserRole.User;
            IsActive = true;
            CreatedAtUtc = DateTime.UtcNow;
        }

        public void UpdateLastLogin()
        {
            LastLoginAtUtc = DateTime.UtcNow;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        public void SetPasswordResetToken(
            string token,
            DateTime expiryUtc)
        {
            PasswordResetToken = token;
            PasswordResetTokenExpiryUtc = expiryUtc;
        }

        public void ClearPasswordResetToken()
        {
            PasswordResetToken = null;
            PasswordResetTokenExpiryUtc = null;
        }

        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
            ClearPasswordResetToken();
        }
    }
}
