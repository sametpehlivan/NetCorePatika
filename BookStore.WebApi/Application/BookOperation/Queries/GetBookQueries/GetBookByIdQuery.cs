using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Application.BookOperation.Queries.GetBookQueries;


public class GetBookQuery
{
    private readonly IBookDBContext _context ;
    private readonly IMapper _mapper; 
    public GetBookQuery(IBookDBContext context,IMapper mapper)
    {
       _context = context;
       _mapper = mapper;
    }
    public async Task<GetBookVM> handleAsync(int id){
       
       var book = await _context.Books.AsQueryable()
                                       .Include(b => b.Author) 
                                       .Include(b => b.BookGenres)
                                       .ThenInclude(bg => bg.Genre)
                                       .FirstOrDefaultAsync(b => b.Id == id);
       if(book == null) throw new Exception("Not found book");
       var response = _mapper.Map<GetBookVM>(book);
       return response;
    }
}
public class GetBookVM 
{
  public int Id {get; set;}
  public string Title { get; set; }  
  public int PageCount { get; set; }
  public List<string> Genres {get; set;}
  public string AuthorName {get; set;}
  public DateTime PublishTime {get; set;}
}
