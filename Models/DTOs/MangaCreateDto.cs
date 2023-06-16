#nullable disable

public class MangaCreateDto : IMangaCreate
{
    public string Name { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly? FinishedDate { get; set; }
}