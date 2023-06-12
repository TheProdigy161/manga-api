public class MangaUpdateDto : IMangaUpdate
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public MangaUpdateDto(string _name)
    {
        this.Name = _name;
    }
}