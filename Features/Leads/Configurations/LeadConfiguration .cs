using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReplyFlow.Features.Leads.Entities;

namespace ReplyFlow.Features.Leads.Configurations
{
    public class LeadConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> builder)
        {
            builder.ToTable("Leads");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);


            builder.Property(x => x.Phone)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.BusinessType)
            .IsRequired()
            .HasConversion<int>();

            builder.Property(x => x.CreatedAt)
                 .HasDefaultValueSql("GETUTCDATE()")
                 .IsRequired();
            builder.HasIndex(x => x.Phone);
            builder.HasIndex(x => x.CreatedAt);
            builder.HasIndex(x => x.BusinessType);
        }
    }
}
