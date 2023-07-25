using Microsoft.EntityFrameworkCore;

public class MangaService
{
    private ILogger<MangaService> _logger { get; set; }
    private MangaContext _mangaContext { get; set; }

    public MangaService(ILogger<MangaService> logger, MangaContext mangaContext)
    {
        _logger = logger;
        _mangaContext = mangaContext;
    }

    public async Task<Manga?> GetMangaById(Guid id)
    {
        return await _mangaContext.Manga.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Manga>> GetAllManga()
    {
        return await _mangaContext.Manga.ToArrayAsync();
    }

    public async Task<bool> CreateManga(Manga newManga)
    {
        try
        {
            await _mangaContext.Manga.AddAsync(newManga);
            await _mangaContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to create Manga: {e.Message}");
            return false;
        }
    }

    public async Task<bool> UpdateManga(Manga manga)
    {
        try
        {
            _mangaContext.Manga.Update(manga);
            await _mangaContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            _logger.LogError($"Failed to update Manga: {e.Message}");
            return false;
        }
    }
}