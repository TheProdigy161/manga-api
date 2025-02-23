namespace MangaApi.Models.Interfaces;

public interface IBaseEntity
{
    Guid Id { get; set; }
    DateTime CreatedDate { get; set; }
    DateTime? UpdatedDate { get; set; }
    DateTime? DeletedDate { get; set; }
    bool Deleted { get; set; }
}