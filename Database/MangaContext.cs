using MangaApi.Database.Configs;
using MangaApi.Database.Seeding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MangaApi.Models;
using MangaApi.Models.Converters;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MangaApi.Database;

public class MangaContext : IdentityDbContext<User>
{
    public DbSet<Manga> Manga { get; set; } = default!;
    public DbSet<Author> Author { get; set; } = default!;

    public MangaContext(DbContextOptions<MangaContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //Property Configurations
        builder.Author();
        builder.Manga();

        base.OnModelCreating(builder);
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
        List<EntityEntry<BaseEntity>> trackedEntries = ChangeTracker.Entries<BaseEntity>()
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