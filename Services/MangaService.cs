using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class MangaService
{
    private ILogger<MangaService> _logger { get; set; }
    private MangaContext _mangaContext { get; set; }
    private IMapper _mapper { get; set; }

    public MangaService(ILogger<MangaService> logger, MangaContext mangaContext, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
        _mangaContext = mangaContext;
    }

    public async Task<Manga> GetMangaById(Guid id)
    {
        return await _mangaContext.Manga.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<ICollection<Manga>> GetAllManga(Guid? authorId = null)
    {
        if (authorId is null)
        {
            return await _mangaContext.Manga.ToArrayAsync();
        }
        
        return await _mangaContext.Manga.Where(x => x.AuthorId == authorId).ToArrayAsync();
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
            Manga existingManga = await _mangaContext.Manga.AsNoTracking().FirstOrDefaultAsync(x => x.Id == manga.Id);

            if (existingManga is null)
            {
                throw new Exception($"Failed to find Manga with the id {manga.Id}.");
            }

            _mapper.Map<BaseEntity, Manga>(existingManga, manga);
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