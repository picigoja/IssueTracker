using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Data
{
    public class IssueTrackerContext : DbContext
    {
        public IssueTrackerContext (DbContextOptions<IssueTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Models.User> User { get; set; } = default!;

        public DbSet<Models.Project>? Project { get; set; }
    }
}
