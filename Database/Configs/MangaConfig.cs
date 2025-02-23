using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MangaApi.Models;

namespace MangaApi.Database.Configs;

public static class MangaConfig
{
    public static void Manga(this ModelBuilder builder)
    {
        EntityTypeBuilder<Manga> manga = builder.Entity<Manga>();

        manga.ToTable("Manga", "Manga");

        manga.HasKey(x => x.Id);
        manga.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
        manga.HasIndex(x => x.Name).IsUnique();
        manga.Property(x => x.Name).IsRequired();
        manga.Property(x => x.ImageUrl).IsRequired();
        manga.Property(x => x.ReleaseDate).HasDefaultValueSql("now()").IsRequired();
        manga.Property(x => x.FinishedDate);

        manga.HasOne(x => x.Author)
            .WithMany(x => x.Mangas)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();

        manga.BaseEntity();
    }
}