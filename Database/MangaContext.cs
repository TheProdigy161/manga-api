using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class MangaContext : DbContext
{
    public DbSet<Manga> Manga { get; set; } = default!;

    public MangaContext(DbContextOptions<MangaContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("uuid-ossp");
        
        //Property Configurations
        builder.Manga();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        List<EntityEntry<BaseEntity>> trackedEntries = this.ChangeTracker.Entries<BaseEntity>()
            .Where(x =>
                x.Entity is BaseEntity &&
                x.State == EntityState.Added
            )
            .ToList();

        foreach(EntityEntry<BaseEntity> entry in trackedEntries)
		{
            if (entry.State == EntityState.Added)
            {
			    entry.Entity.UpdatedDate = DateTimeOffset.Now;
            }
            else if (entry.State == EntityState.Modified)
            {
			    entry.Entity.CreatedDate = DateTimeOffset.Now;
            }
            else if (entry.State == EntityState.Deleted)
            {
			    entry.Entity.DeletedDate = DateTimeOffset.Now;
                entry.Entity.Deleted = true;
                
                entry.State = EntityState.Modified;
            }
		}

        return await base.SaveChangesAsync(cancellationToken);
    }
}