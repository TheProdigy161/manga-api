namespace MangaApi.Models.Interfaces.Author;

public interface IAuthorUpdate : IAuthorBase
{
    public Guid Id { get; set; }
}