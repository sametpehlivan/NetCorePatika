using System;
using System.Linq;
using AutoMapper;
using BookStore.WebApi.Application.BookOperation.Commands.DeleteBookCommands;
using BookStore.WebApi.Application.BookOperation.Queries.GetBookQueries;
using BookStore.WebApi.BookContext;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace Application.BookOperation.Commands;

public class GetBookQueryTest :IClassFixture<CommonTestFixture>
{
    private readonly BookDBContext _context;
    private readonly IMapper _mapper;
    public GetBookQueryTest(CommonTestFixture testFixture)
    {
        _context = testFixture.context;
        _mapper = testFixture.mapper;
    }
    [Fact]
    public void WhenNotExistBookId_Exception_ShouldBeReturn()
    {
        GetBookQuery command = new GetBookQuery(_context,_mapper);
        
        
        FluentActions
            .Invoking(async () => await command.handleAsync(-8))
            .Should()
            .ThrowAsync<Exception>()
            .Result.And.Message.Should().Be("Not found book");
    }
}