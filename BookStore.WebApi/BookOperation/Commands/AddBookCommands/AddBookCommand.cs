using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookOperation.Commands.AddBookCommands;


public class AddBookCommand 
{
    private readonly BookDBContext _context;
    private readonly IMapper _mapper;
    public AddBookCommand(BookDBContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task handleAsync(AddBookVM model)
    {
        
        if(await _context.Books.AnyAsync(b => b.Title == model.Title )) throw new  Exception("Kitap Mevcut");
        var book = _mapper.Map<Book>(model);
        var m = _mapper.Map<AddBookVM>(book);
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