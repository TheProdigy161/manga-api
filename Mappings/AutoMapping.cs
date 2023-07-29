using AutoMapper;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<BaseEntity, Manga>(MemberList.Source); // Maps BaseEntity to Manga.
        CreateMap<Manga, MangaDto>(); // Maps Manga to MangaDto.
        CreateMap<MangaCreateDto, Manga>(); // Maps MangaCreateDto to Manga.
        CreateMap<MangaUpdateDto, Manga>(); // Maps MangaCreateDto to Manga.
    }
}