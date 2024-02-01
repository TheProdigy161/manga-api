namespace MangaApi.Models.Interfaces;

public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTimeOffset CreatedDate { get; set; }
    DateTimeOffset? UpdatedDate { get; set; }
    DateTimeOffset? DeletedDate { get; set; }
    bool Deleted { get; set; }
}