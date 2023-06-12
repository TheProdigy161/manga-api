public class MangaDto : IMangaCreate, IMangaUpdate
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public MangaDto(string _name)
    {
        this.Name = _name;
    }
}