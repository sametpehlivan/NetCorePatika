using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.WebApi.Application.BookOperation.Commands.AddBookCommands;
using BookStore.WebApi.Application.BookOperation.Commands.UpdateBookCommands;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace Application.BookOperation.Commands;
public class UpdateBookCommandTest :IClassFixture<CommonTestFixture>
{
    private readonly BookDBContext _context;
    private readonly IMapper _mapper;
    public UpdateBookCommandTest(CommonTestFixture testFixture)
    {
        _context = testFixture.context;
        _mapper = testFixture.mapper;
    }
    [Theory]
    [ClassData(typeof(InvalidDataGenerator))]
    public async Task WhenNotExistBookIdOrInvalidGenrOrNotFounAuthor_Exception_ShouldBeReturn(UpdateBookVM model,int id,string message)
    {
        //arrange
        UpdateBookCommand command = new UpdateBookCommand(_context,_mapper);

        FluentActions
            .Invoking(async () => await command.handleAsync(model,id))
            .Should().ThrowAsync<Exception>().Result.And.Message.Should().Be(message);
       
    }
    public class InvalidDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UpdateBookVM { AuthorId = 1, Title = "samet", PageCount= 120,GenreIds = new List<int>{1,2,3},PublishTime = DateTime.Now.AddDays(-1) },120 ,"Not found book"}; //not found book
            yield return new object[] { new UpdateBookVM { AuthorId = 1, Title = "samet", PageCount= 120,GenreIds = new List<int>{1,-2,3},PublishTime = DateTime.Now.AddDays(-1) },1,"Kategori Id bulunamadı" };//invalid genre
            yield return new object[] { new UpdateBookVM { AuthorId = 120, Title = "samet", PageCount= 120,GenreIds = new List<int>{1,2,3},PublishTime = DateTime.Now.AddDays(-1) }, 1,"Yazar mevcut degil"};//not foun author
           // yield return new object[] { new UpdateBookVM { AuthorId = 1, Title = "samet", PageCount= 120,GenreIds = new List<int>{1,2,3},PublishTime = DateTime.Now.AddDays(-1) }, 1, ""}; // valid update book
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
