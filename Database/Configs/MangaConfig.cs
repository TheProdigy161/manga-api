using Microsoft.EntityFrameworkCore;

public static class MangaConfig
{
    public static void Manga(this ModelBuilder builder)
    {
        builder.Entity<Manga>().HasKey(x => x.Id);
        builder.Entity<Manga>().Property(x => x.Id).HasDefaultValueSql("uuid_generate_v4()");
        builder.Entity<Manga>().HasIndex(x => x.Name).IsUnique();
        builder.Entity<Manga>().Property(x => x.Name).IsRequired();
    }
}