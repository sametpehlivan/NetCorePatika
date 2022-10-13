using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookOperation.Commands.AddBookCommands;


public class AddBookCommand 
{
    private readonly BookDBContext _context;
    public AddBookCommand(BookDBContext context)
    {
        _context = context;
    }
    public async Task handleAsync(AddBookVM model)
    {
        var book = await _context.Books.FirstOrDefaultAsync(b => b.Title == model.Title );
        if(book != null) throw new  Exception("Kitap Mevcut");
        book = new Book(){
            Title = model.Title,
            GenreId = model.GenreId,
            PageCount = model.PageCount,
            PublishTime = model.PublishTime
        };
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }
}

public class AddBookVM
{
  public string Title { get; set; }  
  public int GenreId { get; set; }  
  public int PageCount { get; set; }
  public DateTime PublishTime {get; set;}
}