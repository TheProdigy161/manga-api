public class Author : BaseEntity, IAuthor
{
    public string Name { get; set; }
    public Uri ImageUrl { get; set; }
    public DateOnly BirthDate { get; set; }
    public DateOnly? DeathDate { get; set; }

    public virtual ICollection<Manga> Mangas { get; set; } = new List<Manga>();
}