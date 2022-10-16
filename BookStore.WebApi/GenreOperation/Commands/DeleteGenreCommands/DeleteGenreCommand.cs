using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.GenreOperation.Commands.DeleteGenreCommands;
public class DeleteGenreCommand
{
    private readonly BookDBContext _context;
    
    public DeleteGenreCommand(BookDBContext context)
    {
        _context = context;
        
    }
    public async Task handleAsync(int id)
    {
       var genre =  await  _context.Genres.FirstOrDefaultAsync(g => g.Id == id);
       if(genre == null) throw new Exception("Kategori mevcut degil");
       _context.Genres.Remove(genre);
       await _context.SaveChangesAsync();
    }    
}
