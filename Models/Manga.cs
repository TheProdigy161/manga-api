public class Manga : BaseEntity, IManga
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public DateOnly? FinishedDate { get; set; }

    public Manga(string name)
    {
        this.Name = name;
    }
}