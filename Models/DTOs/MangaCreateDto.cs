public class MangaCreateDto : IMangaCreate
{
    public string Name { get; set; }

    public MangaCreateDto(string _name)
    {
        this.Name = _name;
    }
}