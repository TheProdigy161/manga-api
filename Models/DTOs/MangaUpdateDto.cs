#nullable disable

public class MangaUpdateDto : IMangaUpdate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly? FinishedDate { get; set; }
}