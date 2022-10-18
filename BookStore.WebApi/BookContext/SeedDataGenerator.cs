using Microsoft.EntityFrameworkCore;
using BookStore.WebApi.Entities;
namespace BookStore.WebApi.BookContext;

public class SeedDataGenerator 
{
    public static async Task InitalizeAsync(IServiceProvider serviceProvider)
    {
        using var context = new  BookDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookDBContext>>());
        // book seed datas
        if (!await context.Books.AnyAsync())
        {
            await context.Books.AddRangeAsync(new List<Book>
            {
                new Book { Title = "Kitap1", PageCount = 471, AuthorId = 1, PublishTime = new DateTime(1946,4,13) },
                new Book { Title = "Kitap1.2", PageCount = 471, AuthorId = 1, PublishTime = new DateTime(1946,4,13) },
                new Book { Title = "Kitap2", PageCount = 221, AuthorId = 2, PublishTime = new DateTime(1949,4,15) },
                new Book { Title = "Kitap2.2", PageCount = 221, AuthorId = 2, PublishTime = new DateTime(1949,4,15) },
                new Book { Title = "Kitap2.3", PageCount = 221, AuthorId = 2,  PublishTime = new DateTime(1949,4,15) },
                new Book { Title = "Kitap3", PageCount = 221, AuthorId = 3, PublishTime = new DateTime(1949,4,15) },
                new Book { Title = "Bozkurtlar Diriliyor", PageCount = 221, AuthorId = 4, PublishTime = new DateTime(1949,4,15) },
            });
        }      
        //author seed datas    
        if(! await context.Authors.AnyAsync())
        {
            await context.Authors.AddRangeAsync(new List<Author>{
                new Author() { FirstName ="Yazar", LastName="Bir", Birthday = DateTime.Now.AddYears(-50) },
                new Author() { FirstName ="Yazar", LastName="Iki", Birthday = DateTime.Now.AddYears(-40) },
                new Author() { FirstName ="Yazar", LastName="Uc",  Birthday = DateTime.Now.AddYears(-38) },
                new Author() { FirstName ="Yazar", LastName = "Atsiz", Birthday = new DateTime(19,1,12)  },  
            });
        } 
        //genre seed datas
        if(! await context.Genres.AnyAsync())
        {
            await context.Genres.AddRangeAsync(new List<Genre>()
            {
                new Genre() { Name = "Fantasy" },
                new Genre() { Name = "Historical Fiction" },
                new Genre() { Name = "Romance" }
            });
        } 
        //bookgenre seed datas
        if(! await context.BookGenres.AnyAsync())
        {
            await context.BookGenres.AddRangeAsync(new List<BookGenre>(){
                new BookGenre { BookId=1, GenreId=1 },
                new BookGenre { BookId=1, GenreId=2 },
                new BookGenre { BookId=1, GenreId=3 },
                new BookGenre { BookId=2, GenreId=1 }, 
                new BookGenre { BookId=2, GenreId=2 }, 
                new BookGenre { BookId=3, GenreId=3 }, 
                new BookGenre { BookId=4, GenreId=3 }, 
                new BookGenre { BookId=5, GenreId=2 },
                new BookGenre { BookId=6, GenreId=1 },
                new BookGenre { BookId=7, GenreId=1 },
            });
        }
        await context.SaveChangesAsync();
        return;
    }
}