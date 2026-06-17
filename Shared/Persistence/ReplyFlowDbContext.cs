using Microsoft.EntityFrameworkCore;
using ReplyFlow.Features.Auth.Entites;

namespace ReplyFlow.Shared.Persistence
{
    public class ReplyFlowDbContext : DbContext
    {
        public ReplyFlowDbContext(
            DbContextOptions<ReplyFlowDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users => Set<User>();
        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                                 typeof(ReplyFlowDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
