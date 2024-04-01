using Microsoft.EntityFrameworkCore;
using MangaApi.Models;
using Newtonsoft.Json;

namespace MangaApi.Database.Seeding;

public static class DataSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        modelBuilder.TrySeedAuthor();
        modelBuilder.TrySeedManga();
    }

    private static void TrySeedAuthor(this ModelBuilder modelBuilder)
    {
        string authorJson = File.ReadAllText("Database/Seeding/Data/AuthorData.json");
        List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(authorJson);

        if (authors is not null)
        {
            foreach (Author author in authors)
            {
                modelBuilder.Entity<Author>().HasData(new Author
                {
                    Id = author.Id,
                    Name = author.Name,
                    ImageUrl = author.ImageUrl,
                    BirthDate = author.BirthDate,
                    DeathDate = author.DeathDate
                });
            }
        }
    }

    private static void TrySeedManga(this ModelBuilder modelBuilder)
    {
        string mangaJson = File.ReadAllText("Database/Seeding/Data/MangaData.json");
        List<Manga> mangas = JsonConvert.DeserializeObject<List<Manga>>(mangaJson);

        if (mangas is not null)
        {
            foreach (Manga manga in mangas)
            {
                modelBuilder.Entity<Manga>().HasData(new Manga
                {
                    Id = manga.Id,
                    Name = manga.Name,
                    AuthorId = manga.AuthorId,
                    ImageUrl = manga.ImageUrl,
                    ReleaseDate = manga.ReleaseDate,
                    FinishedDate = manga.FinishedDate
                });
            }
        }
    }
}