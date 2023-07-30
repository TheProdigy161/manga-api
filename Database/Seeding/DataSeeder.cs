using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public static class DataSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        string mangaJson = File.ReadAllText("Database\\Seeding\\Manga.json");
        List<MangaCreateDto>? mangas = JsonConvert.DeserializeObject<List<MangaCreateDto>>(mangaJson);

        if (mangas is not null)
        {
            foreach (MangaCreateDto manga in mangas)
            {
                modelBuilder.Entity<Manga>().HasData(new Manga
                {
                    Name = manga.Name,
                    ImageUrl = manga.ImageUrl,
                    ReleaseDate = manga.ReleaseDate,
                    FinishedDate = manga.FinishedDate
                });
            }
        }
    }
}