using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Movie.Entity;

namespace Movie.Context
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        public DbSet<MovieEntity> Movies { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {
                var entities = ChangeTracker
                    .Entries()
                    .Where(e => e.Entity != null &&
                                (e.State == EntityState.Modified ||
                                 e.State == EntityState.Added ||
                                 e.State == EntityState.Deleted))
                    .ToList();

                foreach (var entity in entities)
                {
                    entity.State = entity.State switch
                    {
                        EntityState.Added => EntityState.Modified,
                        _ => EntityState.Unchanged,
                    };
                }
                throw;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MovieContext).Assembly);
        }
    }
}
