using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MangaApi.Models;

namespace MangaApi.Database.Configs;

public static class AuthorConfig
{
    public static void Author(this ModelBuilder builder)
    {
        EntityTypeBuilder<Author> model = builder.Entity<Author>();

        model.ToTable("Author", "Author");

        model.HasKey(x => x.Id);
        model.Property(x => x.Id).HasDefaultValueSql("gen_random_uuid()");
        model.Property(x => x.Name).IsRequired();
        model.Property(x => x.ImageUrl).IsRequired();
        model.Property(x => x.BirthDate).IsRequired();
        model.Property(x => x.DeathDate);

        model.BaseEntity();
    }
}