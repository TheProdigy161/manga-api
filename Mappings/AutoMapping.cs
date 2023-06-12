using AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Manga, MangaDto>(); // Maps Manga to MangaDto.
        CreateMap<MangaCreateDto, Manga>(); // Maps MangaCreateDto to Manga.
        CreateMap<MangaUpdateDto, Manga>(); // Maps MangaCreateDto to Manga.
    }
}