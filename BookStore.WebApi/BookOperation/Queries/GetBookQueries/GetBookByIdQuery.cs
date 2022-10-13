using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookOperation.Queries.GetBookQueries;


public class GetBookQuery
{
    private readonly BookDBContext _context ;
    public GetBookQuery(BookDBContext context)
    {
       _context = context;
    }
    public async Task<GetBookVM> handleAsync(int id){
       
       var book = await _context.Books.Where(b => b.Id == id).Select(b =>  new GetBookVM()
        {
            Id = b.Id,
            Title = b.Title,
            Genre = ((GenreEnum)b.GenreId).ToString(),
            PageCount = b.PageCount,
            PublishTime = b.PublishTime
        }).FirstOrDefaultAsync();
       if(book == null) throw new Exception("Not found book");
       return book;
    }
}
public class GetBookVM 
{
  public int Id {get; set;}
  public string Title { get; set; }  
  public string Genre { get; set; }  
  public int PageCount { get; set; }
  public DateTime PublishTime {get; set;}
}
