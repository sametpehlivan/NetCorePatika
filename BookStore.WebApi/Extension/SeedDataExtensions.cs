using BookStore.WebApi.BookContext;

namespace BookStore.WebApi.Extensions;
public static class SeedDataExtension
{
    public async  static Task  SeedDataInMemory(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;
        await SeedDataGenerator.InitalizeAsync(services);
    }
}