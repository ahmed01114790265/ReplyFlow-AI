using Microsoft.EntityFrameworkCore;
using ReplyFlow.Features.Auth.Entites;
using ReplyFlow.Features.Leads.Entities;

namespace ReplyFlow.Shared.Persistence
{
    public class ReplyFlowDbContext : DbContext
    {
        public ReplyFlowDbContext(
            DbContextOptions<ReplyFlowDbContext> options)
            : base(options)
        {
        }
        public DbSet<Lead> Leads=> Set<Lead>();
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
