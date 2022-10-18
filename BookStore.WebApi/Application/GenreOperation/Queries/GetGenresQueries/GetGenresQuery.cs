using AutoMapper;
using BookStore.WebApi.BookContext;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Application.GenreOperation.GetGenresQueries;

public class GetGenresQuery
{
    IBookDBContext _context;
    IMapper _mapper;

    public GetGenresQuery(IBookDBContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<List<GetGenresVM>> handleAsync()
    {
        var genres = await _context.Genres.AsQueryable().Include(b => b.BookGenres).ThenInclude(bg => bg.Book ).ToListAsync();
        var list = _mapper.Map<List<GetGenresVM>>(genres);
        return list;
    }

}
public class GetGenresVM
{
    public int Id {get; set;}
    public string Name {get; set;}
    public  List<string> Books {get; set;}
}