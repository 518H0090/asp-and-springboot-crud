using crud_aspdotnet_core.Configurations;
using crud_aspdotnet_core.Entities;
using Microsoft.EntityFrameworkCore;

namespace crud_aspdotnet_core.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new VideoGameConfiguration());
        }
    }
}
