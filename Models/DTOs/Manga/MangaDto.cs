public class MangaDto : IManga
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Uri ImageUrl { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly? FinishedDate { get; set; }
    
    public Guid AuthorId { get; set; }
    public Author Author { get; set; }
}