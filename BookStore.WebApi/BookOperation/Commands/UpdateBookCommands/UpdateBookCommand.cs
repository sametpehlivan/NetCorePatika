using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookOperation.Commands.UpdateBookCommands;


public class UpdateBookCommand
{
    private readonly BookDBContext _context ;
    private readonly IMapper _mapper;
    public UpdateBookCommand(BookDBContext context,IMapper mapper)
    {
       _context = context;
       _mapper = mapper;

    }
    public async Task handleAsync(UpdateBookVM model,int id){
      
     var book =  _context.Books.FirstOrDefault(b => b.Id == id);
     if(book == null) throw new  Exception("Not found book");
     
     book = _mapper.Map<UpdateBookVM,Book>(model,destination:book);
     var upd = _mapper.Map<Book,UpdateBookVM>(book);
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