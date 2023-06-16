#nullable disable

public class MangaDto : IManga
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly? FinishedDate { get; set; }
}