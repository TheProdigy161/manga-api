using AutoMapper;
using MangaApi.Database;
using MangaApi.Models;

namespace MangaApi.Services;

public class AuthorService : BaseService<Author>
{
    public AuthorService(
        ILogger<AuthorService> logger,
        MangaContext mangaContext,
        IMapper mapper
	) : base(logger, mangaContext, mapper) { }
}