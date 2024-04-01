namespace MangaApi.Models.Interfaces.Manga;

public interface IMangaBase
{
    public string Name { get; set; }
    public Uri ImageUrl { get; set; }
    public Guid AuthorId { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly? FinishedDate { get; set; }
}