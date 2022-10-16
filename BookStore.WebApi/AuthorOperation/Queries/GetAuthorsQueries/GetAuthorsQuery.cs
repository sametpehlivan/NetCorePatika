
using AutoMapper;
using BookStore.WebApi.BookContext;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.AuthorOperation.Queries.GetAuthorsQueries;
public class GetAuthorsQuery 
{
    
    private readonly BookDBContext _context ;
    private readonly IMapper _mapper;
    public GetAuthorsQuery(BookDBContext context,IMapper mapper)
    {
       _context = context;
       _mapper = mapper;
    }
    public  async Task<List<GetAuthorsVM>>  handleAsync()
    {
        var authors = await _context.Authors.AsQueryable().Include(a => a.Books).ToListAsync();
        var list = _mapper.Map<List<GetAuthorsVM>>(authors);
        return list;
    }
}
public class GetAuthorsVM
{
   public int Id  {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public List<string> Books {get;set;}
    public DateTime Birthday {get; set;}
}