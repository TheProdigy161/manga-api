using AutoMapper;
using MangaApi.Models.DTOs.Manga;
using Microsoft.AspNetCore.Mvc;
using MangaApi.Models;
using MangaApi.Services;
using MangaApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace MangaApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class MangaController : ControllerBase
{
	private readonly IMapper _mapper;
    private IBaseService<Manga> _mangaService { get; set; }
    private readonly ILogger<MangaController> _logger;

    public MangaController(ILogger<MangaController> logger, IMapper mapper, MangaService mangaService)
    {
        _logger = logger;
        _mapper = mapper;
        _mangaService = mangaService;
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        Manga foundManga = await _mangaService.GetById(id, x => x.Author);

        if (foundManga is null)
        {
            return BadRequest($"Failed to find Manga with the id {id}.");
        }

        return Ok(_mapper.Map<MangaDto>(foundManga));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] Guid? authorId = null)
    {
        ICollection<Manga> mangas = await _mangaService.GetAll
        (
            authorId != null ? x => x.AuthorId == authorId : null,
            x => x.Author
        );

        return Ok(_mapper.Map<ICollection<MangaDto>>(mangas));
    }

    [AllowAnonymous]
    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginated([FromQuery] PaginationOptions paginationOptions)
    {
        ICollection<Manga> mangas = await _mangaService.GetAll(paginationOptions);

        return Ok(_mapper.Map<ICollection<MangaDto>>(mangas));
    }

    [HttpPost]
    public async Task<IActionResult> Create(MangaCreateDto data)
    {
        Manga newManga = _mapper.Map<Manga>(data);

        bool mangaCreated = await _mangaService.Create(newManga);

        if (!mangaCreated)
        {
            return BadRequest("Failed to create new Manga.");
        }

        return Ok(_mapper.Map<MangaDto>(newManga));
    }

    [HttpPut]
    public async Task<IActionResult> Update(MangaUpdateDto data)
    {
        Manga manga = _mapper.Map<Manga>(data);

        bool mangaUpdated = await _mangaService.Update(manga);

        if (!mangaUpdated)
        {
            return BadRequest("Failed to update Manga.");
        }

        return Ok("Successfully updated Manga.");
    }
}
