using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public static class DataSeeder
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        string mangaJson = File.ReadAllText("Database\\Seeding\\Data\\MangaData.json");
        List<Manga>? mangas = JsonConvert.DeserializeObject<List<Manga>>(mangaJson);

        if (mangas is not null)
        {
            foreach (Manga manga in mangas)
            {
                modelBuilder.Entity<Manga>().HasData(new Manga
                {
                    Id = manga.Id,
                    Name = manga.Name,
                    ImageUrl = manga.ImageUrl,
                    ReleaseDate = manga.ReleaseDate,
                    FinishedDate = manga.FinishedDate
                });
            }
        }
    }
}