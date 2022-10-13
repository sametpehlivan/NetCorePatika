using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookOperation.Commands.UpdateBookCommands;


public class UpdateBookCommand
{
    private readonly BookDBContext _context ;
    public UpdateBookCommand(BookDBContext context)
    {
       _context = context;
    }
    public async Task handleAsync(UpdateBookVM model,int id){
      
     var book =  _context.Books.FirstOrDefault(b => b.Id == id);
     if(book == null) throw new  Exception("Not found book");
     book.Title = model.Title;
     book.GenreId = model.GenreId;
     book.PageCount = model.PageCount;
     book.PublishTime = model.PublishTime;
     await _context.SaveChangesAsync();
    }
}

public class UpdateBookVM 
{

  public string Title { get; set; }  
  public int GenreId { get; set; }  
  public int PageCount { get; set; }
  public DateTime PublishTime {get; set;}
}