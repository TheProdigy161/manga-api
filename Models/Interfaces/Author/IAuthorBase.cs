namespace MangaApi.Models.Interfaces.Author;

public interface IAuthorBase
{
    public string Name { get; set; }
    public Uri ImageUrl { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateOnly? DeathDate { get; set; }
}