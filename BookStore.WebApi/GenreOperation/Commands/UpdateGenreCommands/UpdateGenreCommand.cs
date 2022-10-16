using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.GenreOperation.Commands.UpdateGenreCommands;
public class UpdateGenreCommand
{
    private readonly BookDBContext _context;
    private readonly IMapper _mapper;
    public UpdateGenreCommand(BookDBContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task handleAsync(int id, UpdateGenreVM model)
    {
       var genre =  await  _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
       if(genre == null) throw new Exception("Kategori mevcut degil");
       genre = _mapper.Map<UpdateGenreVM,Genre>(model,destination:genre);
       _context.Genres.Update(genre);
       await _context.SaveChangesAsync();
    }    
}
public class UpdateGenreVM
{
    public string Name {get; set;}
}