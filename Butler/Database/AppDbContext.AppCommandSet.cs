using Microsoft.EntityFrameworkCore;

namespace Butler.Database
{
    public partial class AppDbContext
    {
        public DbSet<AppCommandSetEntity> AppCommandSets { get; set; }
    }
}
