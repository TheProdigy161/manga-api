using MangaApi.Models.Interfaces;

public class BaseEntity : IBaseEntity
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }
    public DateTimeOffset? DeletedDate { get; set; }
    public bool Deleted { get; set; }
}