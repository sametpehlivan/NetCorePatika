
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookOperation.Queries.GetBooksQueries;
public class GetBooksQuery
{
    private readonly BookDBContext _context ;
    public GetBooksQuery(BookDBContext context)
    {
       _context = context;
    }
    public  async Task<List<GetBooksVM>>  handleAsync(){
        return await _context.Books.Select(b =>  new GetBooksVM()
        {
            Id = b.Id,
            Title = b.Title,
            Genre = ((GenreEnum)b.GenreId).ToString(),
            PageCount = b.PageCount,
            PublishTime = b.PublishTime
        }).ToListAsync();
    }
}

public class GetBooksVM 
{
  public int Id {get; set;}
  public string Title { get; set; }  
  public string Genre { get; set; }  
  public int PageCount { get; set; }
  public DateTime PublishTime {get; set;}
}