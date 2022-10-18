using System.Threading.Tasks;
using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Mapping;
using Microsoft.EntityFrameworkCore;

namespace TestSetup;
public class CommonTestFixture
{
    public BookDBContext context {get; set;}
    public IMapper mapper {get; set;}
    public CommonTestFixture()
    {
        var options = new DbContextOptionsBuilder<BookDBContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").Options;
        context = new BookDBContext(options);
        context.Database.EnsureCreated();
        context.AddAuthors();
        context.AddBooks();
        context.AddGenres();
        context.AddBookGenre();
        context.SaveChanges();
        mapper = new MapperConfiguration(cfg =>{
            cfg.AddProfile<AuthorMappingProfile>();
            cfg.AddProfile<GenresMappingProfile>();
            cfg.AddProfile<BookMappingProfile>();
        }).CreateMapper();
    }
}