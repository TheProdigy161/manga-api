using AutoMapper;
using MangaApi.Models.DTOs.Author;
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
public class AuthorController : ControllerBase
{
    private readonly IMapper _mapper;
    private IBaseService<Author> _authorService { get; set; }
    private readonly ILogger<AuthorController> _logger;

    public AuthorController(ILogger<AuthorController> logger, IMapper mapper, AuthorService authorService)
    {
        _logger = logger;
        _mapper = mapper;
        _authorService = authorService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        Author foundAuthor = await _authorService.GetById(id);

        if (foundAuthor is null)
        {
            return BadRequest($"Failed to find Author with the id {id}.");
        }

        return Ok(_mapper.Map<AuthorDto>(foundAuthor));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ICollection<Author> authors = await _authorService.GetAll();

        return Ok(_mapper.Map<ICollection<AuthorDto>>(authors));
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetPaginated([FromQuery] PaginationOptions paginationOptions)
    {
        ICollection<Author> mangas = await _authorService.GetAll(paginationOptions);

        return Ok(_mapper.Map<ICollection<AuthorDto>>(mangas));
    }

    [HttpPost]
    public async Task<IActionResult> Create(AuthorCreateDto data)
    {
        Author newAuthor = _mapper.Map<Author>(data);

        bool authorCreated = await _authorService.Create(newAuthor);

        if (!authorCreated)
        {
            return BadRequest("Failed to create new Author.");
        }

        return Ok(_mapper.Map<AuthorDto>(newAuthor));
    }

    [HttpPut]
    public async Task<IActionResult> Update(AuthorUpdateDto data)
    {
        Author author = _mapper.Map<Author>(data);

        bool authorUpdated = await _authorService.Update(author);

        if (!authorUpdated)
        {
            return BadRequest("Failed to update Author.");
        }

        return Ok("Successfully updated Author.");
    }
}
