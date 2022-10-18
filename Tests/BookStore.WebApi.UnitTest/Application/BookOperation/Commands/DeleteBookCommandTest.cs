using System;
using System.Linq;
using BookStore.WebApi.Application.BookOperation.Commands.DeleteBookCommands;
using BookStore.WebApi.BookContext;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace Application.BookOperation.Commands;

public class DeleteBookCommandTest :IClassFixture<CommonTestFixture>
{
    private readonly BookDBContext _context;
    public DeleteBookCommandTest(CommonTestFixture testFixture)
    {
        _context = testFixture.context;
    }
    [Fact]
    public void WhenNotExistBookId_Exception_ShouldBeReturn()
    {
        DeleteBookCommand command = new DeleteBookCommand(_context);
        
        var b = _context.Books.ToList();
        FluentActions
            .Invoking(async () => await command.handleAsync(-8))
            .Should()
            .ThrowAsync<Exception>()
            .Result.And.Message.Should().Be("Not found book");
    }
}