
using AutoMapper;
using BookStore.WebApi.BookContext;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.AuthorOperation.Queries.GetAuthorQueries;
public class GetAuthorQuery 
{
    
    private readonly BookDBContext _context ;
    private readonly IMapper _mapper;
    public GetAuthorQuery(BookDBContext context,IMapper mapper)
    {
       _context = context;
       _mapper = mapper;
    }
    public  async Task<GetAuthorVM>  handleAsync(int id)
    {
        var author = await _context.Authors.AsQueryable().Include(a => a.Books).FirstOrDefaultAsync(a => a.Id == id );
        if(author == null) throw new Exception("Author Not Found");
        var response = _mapper.Map<GetAuthorVM>(author);
        return response;
    }
}
public class GetAuthorVM
{
    public int Id  {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public List<string> Books {get;set;}
    public DateTime Birthday {get; set;}
}