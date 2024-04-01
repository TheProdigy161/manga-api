using MangaApi.Models.Interfaces.Manga;

namespace MangaApi.Models;

public class Manga : BaseEntity, IManga
{
    public string Name { get; set; }
    public Uri ImageUrl { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly? FinishedDate { get; set; }

    public Guid AuthorId { get; set; }
    public Author Author { get; set; } = null!;
}