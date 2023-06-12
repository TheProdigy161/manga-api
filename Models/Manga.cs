public class Manga : IMangaCreate, IMangaUpdate
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Manga(string _name)
    {
        this.Name = _name;
    }
}