using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookOperation.Commands.DeleteBookCommands;
public class DeleteBookCommand
{
    private readonly BookDBContext _context;
    public DeleteBookCommand(BookDBContext context)
    {
        _context = context;
    }
    public async Task handleAsync(int id)
    {
         var book = await _context.Books.AsQueryable()
                                       .Include(b => b.Author)
                                       .Include(b => b.BookGenres)
                                       .ThenInclude(bg => bg.Genre)
                                       .FirstOrDefaultAsync(i => i.Id == id);
        if(book == null) throw new  Exception("Not found book");
       
        _context.Books.Remove(book);
        
        await _context.SaveChangesAsync();
    }
}