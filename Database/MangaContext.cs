using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class MangaContext : DbContext
{
    public DbSet<Manga> Manga { get; set; } = default!;

    public MangaContext(DbContextOptions<MangaContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Property Configurations
        builder.Manga();

        //Seed Data
        builder.Seed();
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        base.ConfigureConventions(builder);

        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>();
            
        builder.Properties<TimeOnly>()
            .HaveConversion<TimeOnlyConverter>();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        List<EntityEntry<BaseEntity>> trackedEntries = this.ChangeTracker.Entries<BaseEntity>()
            .Where(x =>
                x.Entity is BaseEntity &&
                (
                    x.State == EntityState.Added ||
                    x.State == EntityState.Modified ||
                    x.State == EntityState.Deleted
                )
            )
            .ToList();

        foreach(EntityEntry<BaseEntity> entry in trackedEntries)
		{
            if (entry.State == EntityState.Added)
            {
			    entry.Entity.CreatedDate = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Modified)
            {
			    entry.Entity.UpdatedDate = DateTime.UtcNow;
            }
            else if (entry.State == EntityState.Deleted)
            {
			    entry.Entity.DeletedDate = DateTime.UtcNow;
                entry.Entity.Deleted = true;
                
                entry.State = EntityState.Modified;
            }
		}

        return await base.SaveChangesAsync(cancellationToken);
    }
}