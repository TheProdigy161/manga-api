using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public static class MangaConfig
{
    public static void Manga(this ModelBuilder builder)
    {
        EntityTypeBuilder<Manga> manga = builder.Entity<Manga>();
        manga.HasKey(x => x.Id);
        manga.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
        manga.HasIndex(x => x.Name).IsUnique();
        manga.Property(x => x.Name).IsRequired();
        manga.Property(x => x.ReleaseDate).HasDefaultValueSql("now()").IsRequired();
        manga.Property(x => x.FinishedDate);

        manga.BaseEntity();
    }
}