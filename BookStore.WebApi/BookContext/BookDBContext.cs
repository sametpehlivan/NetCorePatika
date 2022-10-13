using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookContext;
public class BookDBContext : DbContext
{
    public DbSet<Book> Books {get; set;}

    public BookDBContext(DbContextOptions<BookDBContext> options):base(options)
    {
        
    }

}