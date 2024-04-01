using MangaApi.Models.Interfaces.Author;

namespace MangaApi.Models.DTOs.Author;

public class AuthorUpdateDto : IAuthorUpdate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Uri ImageUrl { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateOnly? DeathDate { get; set; }
}