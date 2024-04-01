namespace MangaApi.Models.Interfaces.Manga;

public interface IMangaUpdate : IMangaBase
{
    public Guid Id { get; set; }
}