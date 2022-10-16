using AutoMapper;
using BookStore.WebApi.BookContext;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.GenreOperation.GetGenresQueries;

public class GetGenresQuery
{
    BookDBContext _context;
    IMapper _mapper;

    public GetGenresQuery(BookDBContext context,IMapper mapper)
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