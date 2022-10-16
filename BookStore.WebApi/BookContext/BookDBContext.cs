using Microsoft.EntityFrameworkCore;
using BookStore.WebApi.Entities;
namespace BookStore.WebApi.BookContext;
public class BookDBContext : DbContext
{
    public DbSet<Book> Books {get; set;}
    public DbSet<Author> Authors {get; set;}
    public DbSet<BookGenre> BookGenres {get; set;}
    public DbSet<Genre> Genres {get; set;} 

    public BookDBContext(DbContextOptions<BookDBContext> options):base(options)
    {}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //AuthorBook Configuration
       
        modelBuilder.Entity<Book>().HasOne<Author>(b => b.Author).WithMany(b => b.Books).HasForeignKey(ab => ab.AuthorId);
        
        //BookGenre
        modelBuilder.Entity<BookGenre>().HasKey(bg => new {bg.BookId,bg.GenreId});
        modelBuilder.Entity<BookGenre>().HasOne<Book>(bg => bg.Book).WithMany(b => b.BookGenres).HasForeignKey(bg => bg.BookId);
        modelBuilder.Entity<BookGenre>().HasOne<Genre>(bg => bg.Genre).WithMany(b => b.BookGenres).HasForeignKey(bg => bg.GenreId);

        
    }


}