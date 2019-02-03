using Microsoft.EntityFrameworkCore;

namespace Butler.Database
{
    public partial class AppDbContext
    {
        public DbSet<ValueEntity> Values { get; set; }
    }
}
