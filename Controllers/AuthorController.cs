using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace MangaApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
	private readonly IMapper _mapper;
    private AuthorService _authorService { get; set; }
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

        return Ok(_mapper.Map<MangaDto>(foundAuthor));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        ICollection<Author> authors = await _authorService.GetAll();

        return Ok(_mapper.Map<ICollection<AuthorDto>>(authors));
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

        return Ok(_mapper.Map<MangaDto>(newAuthor));
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