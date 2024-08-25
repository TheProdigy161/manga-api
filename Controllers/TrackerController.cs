using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MangaApi.Models;
using MangaApi.Services;
using MangaApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using MangaApi.Models.DTOs.Manga;

namespace MangaApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class TrackerController : ControllerBase
{
    private readonly IMapper _mapper;
    private IBaseService<Author> _authorService { get; set; }
    private IBaseService<Manga> _mangaService { get; set; }
    private readonly ILogger<AuthorController> _logger;

    public TrackerController(ILogger<AuthorController> logger, IMapper mapper, AuthorService authorService, MangaService mangaService)
    {
        _logger = logger;
        _mapper = mapper;
        _authorService = authorService;
        _mangaService = mangaService;
    }

    [HttpGet("{isbn}")]
    public async Task<IActionResult> Get(string isbn)
    {
        MangaDto manga = null;

        // First check if the manga is already in the database.
        Manga foundManga = await _mangaService.Get(isbn);

        // If it is, return the manga.

        // If it isn't, call the tracker service to get the manga details.

        // If the manga is new, check if we need to add the author to the database.

        // If the author is new, add the author to the database.
        
        // Add the manga to the database.

        // Return the manga.

        return Ok(_mapper.Map<MangaDto>(manga));
    }
}
