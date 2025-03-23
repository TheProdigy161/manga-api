using Microsoft.EntityFrameworkCore;
using MangaApi.Models;
using Newtonsoft.Json;

namespace MangaApi.Database.Seeding;

public static class DataSeeder
{
    public static void Seed(this MangaContext context)
    {
        context.TrySeedAuthor();
        context.TrySeedManga();

        context.SaveChanges();
    }

    private static void TrySeedAuthor(this MangaContext context)
    {
        string authorJson = File.ReadAllText("Database/Seeding/Data/AuthorData.json");
        List<Author> authors = JsonConvert.DeserializeObject<List<Author>>(authorJson);

        if (authors is not null)
        {
            foreach (Author author in authors)
            {
                if (!context.Author.Any(a => a.Id == author.Id))
                {
                    // Add new authors
                    context.Author.Add(author);
                }
                else
                {
                    // Update existing authors
                    context.Author.Update(author);
                }
            }
        }
    }

    private static void TrySeedManga(this MangaContext context)
    {
        string mangaJson = File.ReadAllText("Database/Seeding/Data/MangaData.json");
        List<Manga> mangas = JsonConvert.DeserializeObject<List<Manga>>(mangaJson);

        if (mangas is not null)
        {
            foreach (Manga manga in mangas)
            {
                if (!context.Manga.Any(a => a.Id == manga.Id))
                {
                    // Add new mangas
                    context.Manga.Add(manga);
                }
                else
                {
                    // Update existing mangas
                    context.Manga.Update(manga);
                }
            }
        }
    }
}