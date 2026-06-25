using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReplyFlow.Features.Auth.Entites;

namespace ReplyFlow.Features.Auth.Configurations
{
    public sealed class UserConfiguration
        : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PhoneNumber)
                   .HasMaxLength(20)
                   .IsRequired();

            builder.HasIndex(x => x.PhoneNumber)
                   .IsUnique();

            builder.HasIndex(x => x.Role);

            builder.HasIndex(x => x.IsActive);

            builder.HasIndex(x => x.CreatedAtUtc);

            builder.Property(x => x.PasswordHash)
                   .IsRequired();

            builder.Property(x => x.Role)
                   .HasConversion<int>();

            builder.Property(x => x.IsActive)
                   .IsRequired();

            builder.Property(x => x.CreatedAtUtc)
                   .IsRequired();

            builder.Property(x => x.PasswordResetToken)
                   .HasMaxLength(500);

            builder.Property(x => x.PasswordResetTokenExpiryUtc);
        }
    }
}
