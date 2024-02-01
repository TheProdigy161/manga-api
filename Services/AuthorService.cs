using AutoMapper;

public class AuthorService : BaseService<Author>
{
    public AuthorService(
        ILogger<AuthorService> logger,
        MangaContext mangaContext,
        IMapper mapper
	) : base(logger, mangaContext, mapper) { }
}