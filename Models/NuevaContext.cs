using Microsoft.EntityFrameworkCore;

namespace NuevaApi.Models
{
    public class NuevaContext : DbContext
    {
        public NuevaContext(DbContextOptions<NuevaContext> options)
            : base(options)
        {
        }

        public DbSet<NuevaItem> NuevaItems { get; set; }
    }
}