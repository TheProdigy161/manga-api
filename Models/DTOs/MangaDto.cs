#nullable disable

public class MangaDto : IMangaCreate, IMangaUpdate
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}