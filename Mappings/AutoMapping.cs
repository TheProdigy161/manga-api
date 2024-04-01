using AutoMapper;
using MangaApi.Models;
using MangaApi.Models.DTOs.Author;
using MangaApi.Models.DTOs.Manga;

namespace MangaApi.Mappings;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<BaseEntity, Manga>(MemberList.Source); // Maps BaseEntity to Manga.
        CreateMap<Manga, MangaDto>(); // Maps Manga to MangaDto.
        CreateMap<MangaCreateDto, Manga>(); // Maps MangaCreateDto to Manga.
        CreateMap<MangaUpdateDto, Manga>(); // Maps MangaCreateDto to Manga.
        CreateMap<Author, AuthorDto>(); // Maps Author to AuthorDto.
    }
}