using Microsoft.AspNetCore.Mvc;

namespace MangaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class MangaController : ControllerBase
{
    private readonly ILogger<MangaController> _logger;
    private MangaService _mangaService { get; set; }

    public MangaController(ILogger<MangaController> logger, MangaService mangaService)
    {
        _logger = logger;
        _mangaService = mangaService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        Manga? manga = await _mangaService.GetMangaById(id);

        if (manga != null)
        {
            return BadRequest($"Failed to find Manga with the id {id}.");
        }

        return Ok(manga);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Manga newManga)
    {
        bool mangaCreated = await _mangaService.CreateManga(newManga);

        if (!mangaCreated)
        {
            return BadRequest("Failed to create new Manga.");
        }

        return Ok("Successfully created new Manga.");
    }
}
