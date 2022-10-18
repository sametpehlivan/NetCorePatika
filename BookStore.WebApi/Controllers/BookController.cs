using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Application.BookOperation.Commands.AddBookCommands;
using BookStore.WebApi.Application.BookOperation.Commands.DeleteBookCommands;
using BookStore.WebApi.Application.BookOperation.Commands.UpdateBookCommands;
using BookStore.WebApi.Application.BookOperation.Queries.GetBookQueries;
using BookStore.WebApi.Application.BookOperation.Queries.GetBooksQueries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class BookController : ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IBookDBContext _context;
    public BookController(IBookDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    [HttpGet]
    public async Task<IActionResult> GetBooksAsync()
    {
        GetBooksQuery getBooks = new GetBooksQuery(_context,_mapper);
        var books = await getBooks.handleAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookAsync(int id)
    {
        GetBookQuery getBook = new  GetBookQuery(_context,_mapper);
        var book = await  getBook.handleAsync(id);
        return  Ok(book);
    }
    [HttpPost]
    public async Task<IActionResult> AddBookAsync([FromBody] AddBookVM model)
    {
        AddBookCommand add = new AddBookCommand(_context,_mapper);
        await  add.handleAsync(model);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBookAsync([FromRoute] int id,[FromBody] UpdateBookVM model)
    {
        UpdateBookCommand update = new UpdateBookCommand(_context,_mapper);
        await update.handleAsync(model,id);
        return Ok();

    }
    [HttpDelete("{bookId}")]
    public async Task<IActionResult> DeleteAsync(int bookId)
    {
        DeleteBookCommand delete = new DeleteBookCommand(_context);
        await delete.handleAsync(bookId);
        return Ok();
    }
}