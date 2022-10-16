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
        var author = await _context.Authors.AsQueryable().Include(a => a.Books).Where(a => a.Id == id).FirstOrDefaultAsync();
        if(author == null)
            throw new Exception("yazar mevcut değil");
        if(author.Books.Count() > 0) 
            throw new Exception("yazar yayımda olan kitabı mevcut. once kitap'i sil gardasss");
        _context.Authors.Remove(author);
        await _context.SaveChangesAsync();
    }
}