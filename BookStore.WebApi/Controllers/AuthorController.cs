using AutoMapper;
using BookStore.WebApi.AuthorOperation.Commands.AddAuthorCommands;
using BookStore.WebApi.AuthorOperation.Commands.UpdateAuthorCommands;
using BookStore.WebApi.AuthorOperation.Queries.GetAuthorQueries;
using BookStore.WebApi.AuthorOperation.Queries.GetAuthorsQueries;
using BookStore.WebApi.BookContext;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class AuthorController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly BookDBContext _context;
    public AuthorController(BookDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetAuthorsAsync()
    {
        GetAuthorsQuery getAuthors = new GetAuthorsQuery(_context,_mapper);
        var authors = await getAuthors.handleAsync();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorAsync(int id)
    {
        GetAuthorQuery getAuthors = new  GetAuthorQuery(_context,_mapper);
        var author = await  getAuthors.handleAsync(id);
        return  Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> AddAuthorAsync([FromBody] AddAuthorVM model)
    {
        AddAuthorCommand add = new AddAuthorCommand(_context,_mapper);
        await  add.handleAsync(model);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthorAsync([FromRoute] int id,[FromBody] UpdateAuthorVM model)
    {
        UpdateAuthorCommand update = new UpdateAuthorCommand(_context,_mapper);
        await update.handleAsync(id,model);
        return Ok();

    }
    
    [HttpDelete("{authorId}")]
    public async Task<IActionResult> DeleteAsync(int authorId)
    {
        DeleteAuthorCommand delete = new DeleteAuthorCommand(_context);
        await delete.handleAsync(authorId);
        return Ok();
    }
    
}