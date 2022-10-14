
using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
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
        // return await _context.Books.Select(b =>  new GetBooksVM()
        // {
        //     Id = b.Id,
        //     Title = b.Title,
        //     Genre = ((GenreEnum)b.GenreId).ToString(),
        //     PageCount = b.PageCount,
        //     PublishTime = b.PublishTime
        // }).ToListAsync();
        var list = _mapper.Map<List<GetBooksVM>>( await _context.Books.ToListAsync());
       
        return list;
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