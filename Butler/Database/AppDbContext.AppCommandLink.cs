using Microsoft.EntityFrameworkCore;

namespace Butler.Database
{
    public partial class AppDbContext
    {
        public DbSet<AppCommandLinkEntity> AppCommandLinks { get; set; }
    }
}
