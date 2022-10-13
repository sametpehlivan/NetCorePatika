using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.BookContext;

public class SeedDataGenerator 
{
    public static async Task InitalizeAsync(IServiceProvider serviceProvider)
    {
        using var context = new  BookDBContext(serviceProvider.GetRequiredService<DbContextOptions<BookDBContext>>());
        if(await context.Books.AnyAsync()) return;
        await context.Books.AddRangeAsync(new List<Book>{
            new Book
            {
      
                Title = "Kitap1",
                GenreId = 3, 
                PageCount = 471,
                PublishTime = new DateTime(1946,4,13)
            },
                new Book
            {
     
                Title = "Kitap2",
                GenreId = 3, 
                PageCount = 221,
                PublishTime = new DateTime(1949,4,15)
            }
        });
        await context.SaveChangesAsync();
        return;
    }
}