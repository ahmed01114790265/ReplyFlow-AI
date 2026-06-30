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

        // OTP
        public string? ResetCode { get; private set; }

        public DateTime? ResetCodeExpiryUtc { get; private set; }

        private User()
        {
        }

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

        public void SetResetCode(string resetCode, DateTime expiryUtc)
        {
            ResetCode = resetCode;
            ResetCodeExpiryUtc = expiryUtc;
        }

        public bool IsResetCodeValid(string resetCode)
        {
            return ResetCode == resetCode &&
                   ResetCodeExpiryUtc.HasValue &&
                   ResetCodeExpiryUtc.Value > DateTime.UtcNow;
        }

        public void ClearResetCode()
        {
            ResetCode = null;
            ResetCodeExpiryUtc = null;
        }

        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
            ClearResetCode();
        }
    }
}