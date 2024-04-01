using AutoMapper;
using MangaApi.Database;
using MangaApi.Models;

namespace MangaApi.Services;

public class MangaService : BaseService<Manga>
{
    public MangaService(
        ILogger<MangaService> logger,
        MangaContext mangaContext,
        IMapper mapper
	) : base(logger, mangaContext, mapper) { }
}