using AutoMapper;

public class MangaService : BaseService<Manga>
{
    public MangaService(
        ILogger<MangaService> logger,
        MangaContext mangaContext,
        IMapper mapper
	) : base(logger, mangaContext, mapper) { }
}