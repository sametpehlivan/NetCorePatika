using BookStore.WebApi.BookContext;
using BookStore.WebApi.BookOperation.Commands.AddBookCommands;
using BookStore.WebApi.BookOperation.Commands.DeleteBookCommands;
using BookStore.WebApi.BookOperation.Commands.UpdateBookCommands;
using BookStore.WebApi.BookOperation.Queries.GetBookQueries;
using BookStore.WebApi.BookOperation.Queries.GetBooksQueries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class BookController : ControllerBase
{
    
    private readonly BookDBContext _context;
    public BookController(BookDBContext context)
    {
        _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetBooksAsync()
    {
        GetBooksQuery getBooks = new GetBooksQuery(_context);
        var books = await getBooks.handleAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookAsync(int id)
    {
        GetBookQuery getBook = new  GetBookQuery(_context);
        var book = await  getBook.handleAsync(id);
        return  Ok(book);
    }
    [HttpPost]
    public async Task<IActionResult> AddBookAsync([FromBody] AddBookVM model)
    {
        AddBookCommand add = new AddBookCommand(_context);
        await  add.handleAsync(model);
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBookAsync([FromRoute] int id,[FromBody] UpdateBookVM model)
    {
        UpdateBookCommand update = new UpdateBookCommand(_context);
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