using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MangaApi.Models;

namespace MangaApi.Database.Configs;

public static class BaseEntityConfig
{
    public static void BaseEntity<T>(this EntityTypeBuilder<T> entity) where T : BaseEntity
    {
        entity.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()").IsRequired();
        entity.Property(x => x.UpdatedDate);
        entity.Property(x => x.DeletedDate);
        entity.Property(x => x.Deleted);
    }
}