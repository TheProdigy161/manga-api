using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MangaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MangaController : ControllerBase
{
	private readonly IMapper _mapper;
    private MangaService _mangaService { get; set; }
    private readonly ILogger<MangaController> _logger;

    public MangaController(ILogger<MangaController> logger, IMapper mapper, MangaService mangaService)
    {
        _logger = logger;
        _mapper = mapper;
        _mangaService = mangaService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        Manga? foundManga = await _mangaService.GetMangaById(id);

        if (foundManga != null)
        {
            return BadRequest($"Failed to find Manga with the id {id}.");
        }

        return Ok(_mapper.Map<MangaDto>(foundManga));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ICollection<Manga> mangas = await _mangaService.GetAllManga();

        return Ok(_mapper.Map<ICollection<MangaDto>>(mangas));
    }

    [HttpPost]
    public async Task<IActionResult> Create(MangaCreateDto data)
    {
        Manga newManga = _mapper.Map<Manga>(data);

        bool mangaCreated = await _mangaService.CreateManga(newManga);

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

        bool mangaUpdated = await _mangaService.UpdateManga(manga);

        if (!mangaUpdated)
        {
            return BadRequest("Failed to update Manga.");
        }

        return Ok("Successfully updated Manga.");
    }
}
