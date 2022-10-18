using System;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.WebApi.Application.BookOperation.Commands.AddBookCommands;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace Application.BookOperation.Commands;
public class AddBookCommandTest :IClassFixture<CommonTestFixture>
{
    private readonly BookDBContext _context;
    private readonly IMapper _mapper;
    public AddBookCommandTest(CommonTestFixture testFixture)
    {
        _context = testFixture.context;
        _mapper = testFixture.mapper;
    }
    [Fact]
    public async Task WhenAldreadyExistBookTitleAndBookAuthor_Exception_ShouldBeReturn()
    {
        //arrange
        var book = new Book()
        {
            Title = "WhenAldreadyExistBookTitleAndBookAuthor_InvalidOpreationException_ShouldBeReturn", 
            PageCount = 1000,
            PublishTime = new System.DateTime(1990,4,2),
            AuthorId = 8
            
        };
        _context.Books.Add(book);
       await _context.SaveChangesAsync();
       var model = _mapper.Map<AddBookVM>(book);
       AddBookCommand commandTest = new AddBookCommand(_context,_mapper);
      
       
       
       //act & assert
       FluentActions
       .Invoking(async () => await commandTest.handleAsync(model))
       .Should().ThrowAsync<Exception>().Result.And.Message.Should().Be("Kitap Mevcut");
       
    }
}