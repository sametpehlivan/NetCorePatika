using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookContext;
public interface IBookDBContext
{
    public DbSet<Book> Books {get; set;}
    public DbSet<Author> Authors {get; set;}
    public DbSet<BookGenre> BookGenres {get; set;}
    public DbSet<Genre> Genres {get; set;} 

    public  Task<int> SaveChangesAsync(CancellationToken token = default );
    
}