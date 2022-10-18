using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Application.GenreOperation.Commands.DeleteGenreCommands;
public class DeleteGenreCommand
{
    private readonly IBookDBContext _context;
    
    public DeleteGenreCommand(IBookDBContext context)
    {
        _context = context;
        
    }
    public async Task handleAsync(int id)
    {
       var genre =  await  _context.Genres.AsQueryable().Include(a => a.BookGenres).FirstOrDefaultAsync(g => g.Id == id);
       if(genre == null) throw new Exception("Kategori mevcut degil");
       if(genre.BookGenres.Count() > 0) throw new Exception("Kategoriye ait kitaplar mevcut.Once Kitaplari siliniz ya da guncelleyiniz");
       _context.Genres.Remove(genre);
       await _context.SaveChangesAsync();
    }    
}
