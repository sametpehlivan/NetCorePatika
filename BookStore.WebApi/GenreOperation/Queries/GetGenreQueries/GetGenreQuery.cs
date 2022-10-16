using AutoMapper;
using BookStore.WebApi.BookContext;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.GenreOperation.GetGenreQueries;

public class GetGenreQuery
{
    BookDBContext _context;
    IMapper _mapper;

    public GetGenreQuery(BookDBContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<GetGenreVM> handleAsync(int id)
    {
        var genre = await _context.Genres.AsQueryable().Include(b => b.BookGenres).ThenInclude(bg => bg.Book ).FirstOrDefaultAsync(i => i.Id ==  id);
        if(genre == null) throw new Exception("Genre not found");
        var list = _mapper.Map<GetGenreVM>(genre);
        return list;
    }

}
public class GetGenreVM
{
    public int Id {get; set;}
    public string Name {get; set;}
    public  List<string> Books {get; set;}
}