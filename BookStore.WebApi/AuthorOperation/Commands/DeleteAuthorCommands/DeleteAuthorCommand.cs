using BookStore.WebApi.BookContext;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.AuthorOperation.Commands.UpdateAuthorCommands;

public class DeleteAuthorCommand
{
    BookDBContext _context;

    public DeleteAuthorCommand(BookDBContext context)
    {
        _context = context;
    }
    public async Task handleAsync(int id)
    {  
        var author = await _context.Authors.Where(a => a.Id == id).FirstOrDefaultAsync();
        if(author == null)
            throw new Exception("yazar mevcut değil");
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
    }
}