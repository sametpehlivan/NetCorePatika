
using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using BookStore.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookOperation.Queries.GetBooksQueries;
public class GetBooksQuery
{
    private readonly BookDBContext _context ;
    private readonly IMapper _mapper;
    public GetBooksQuery(BookDBContext context,IMapper mapper)
    {
       _context = context;
       _mapper = mapper;
    }
    public  async Task<List<GetBooksVM>>  handleAsync(){
       
       var books = await _context.Books.AsQueryable()
                                       .Include(b => b.Author)
                                       .Include(b => b.BookGenres)
                                       .ThenInclude(bg => bg.Genre)
                                       .ToListAsync();
       
        var list = _mapper.Map<List<GetBooksVM>>(books);
       
        return list;
    }
}

public class GetBooksVM 
{
  public int Id {get; set;}
  public string Title { get; set; }  
  public int PageCount { get; set; }
  public List<string> Genres {get; set;}
  public string AuthorName {get; set;}
  public DateTime PublishTime {get; set;}
}