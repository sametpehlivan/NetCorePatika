using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.GenreOperation.Commands.AddGenreCommands;
public class AddGenreCommand
{
    private readonly BookDBContext _context;
    private readonly IMapper _mapper;
    public AddGenreCommand(BookDBContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task handleAsync(AddGenreVM model)
    {
       var genre =  await  _context.Genres.FirstOrDefaultAsync(g => g.Name.Trim().ToLower() == model.Name.Trim().ToLower());
       if(genre != null) throw new Exception("Kategori mevcut");
       genre = _mapper.Map<Genre>(model);
       await _context.Genres.AddAsync(genre);
       await _context.SaveChangesAsync();
    }    
}
public class AddGenreVM
{
    public string Name {get; set;}
}