using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.BookOperation.Commands.AddBookCommands;
using BookStore.WebApi.BookOperation.Commands.DeleteBookCommands;
using BookStore.WebApi.BookOperation.Commands.UpdateBookCommands;
using BookStore.WebApi.BookOperation.Queries.GetBookQueries;
using BookStore.WebApi.BookOperation.Queries.GetBooksQueries;
using BookStore.WebApi.GenreOperation.Commands.AddGenreCommands;
using BookStore.WebApi.GenreOperation.Commands.DeleteGenreCommands;
using BookStore.WebApi.GenreOperation.Commands.UpdateGenreCommands;
using BookStore.WebApi.GenreOperation.GetGenreQueries;
using BookStore.WebApi.GenreOperation.GetGenresQueries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class GenreController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly BookDBContext _context;
    public GenreController(BookDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetGenresAsync()
    {
        GetGenresQuery getGenres = new GetGenresQuery(_context,_mapper);
        var genres = await getGenres.handleAsync();
        return Ok(genres);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGenreAsync(int id)
    {
        GetGenreQuery getGenre = new  GetGenreQuery(_context,_mapper);
        var genre = await  getGenre.handleAsync(id);
        return  Ok(genre);
    }


    [HttpPost]
    public async Task<IActionResult> AddGenreAsync([FromBody] AddGenreVM model)
    {
        AddGenreCommand add = new AddGenreCommand(_context,_mapper);
        await  add.handleAsync(model);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGenreAsync([FromRoute] int id,[FromBody] UpdateGenreVM model)
    {
        UpdateGenreCommand update = new UpdateGenreCommand(_context,_mapper);
        await update.handleAsync(id,model);
        return Ok();

    }

    [HttpDelete("{genreId}")]
    public async Task<IActionResult> DeleteAsync(int genreId)
    {
        DeleteGenreCommand delete = new DeleteGenreCommand(_context);
        await delete.handleAsync(genreId);
        return Ok();
    }
    
}