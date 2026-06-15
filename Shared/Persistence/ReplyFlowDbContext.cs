using Microsoft.EntityFrameworkCore;

namespace ReplyFlow.Shared.Persistence
{
    public class ReplyFlowDbContext : DbContext
    {
        public ReplyFlowDbContext(
            DbContextOptions<ReplyFlowDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ReplyFlowDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
