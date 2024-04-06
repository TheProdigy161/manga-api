using MangaApi.Models.Interfaces.Manga;

namespace MangaApi.Models;

public class PaginationOptions : IPaginationOptions
{
    private const int _maxPageSize = 50;
    
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = _maxPageSize;
    public int Offset => (Page - 1) * PageSize;
    public int Limit => PageSize > _maxPageSize ? _maxPageSize : PageSize;
}