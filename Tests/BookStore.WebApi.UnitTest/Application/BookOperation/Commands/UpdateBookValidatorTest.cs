using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.WebApi.Application.BookOperation.Commands.AddBookCommands;
using BookStore.WebApi.Application.BookOperation.Commands.UpdateBookCommands;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Validators.BookValidators;
using BookStore.WebApi.Entities;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace Application.BookOperation.Commands;
public class UpdateBookValidatorTest :IClassFixture<CommonTestFixture>
{
 
    [Theory]
    [ClassData(typeof(InvalidDataGenerator))]
    public async Task WhenGivenInvalidProperties_Exception_ShouldBeReturn(UpdateBookVM model)
    {
        UpdateBookValidator validator = new UpdateBookValidator(); 
         var errors = validator.Validate(model);
            errors.Errors.Count.Should().BeGreaterThan(0);


       
    }
    public class InvalidDataGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new UpdateBookVM { AuthorId = 0, Title = "deneme", PageCount= 120,GenreIds = new List<int>{1,2,3},PublishTime = DateTime.Now.AddDays(-1) }}; 
            yield return new object[] { new UpdateBookVM { AuthorId = 1, Title = "", PageCount= 120,GenreIds = new List<int>{1,2,3},PublishTime = DateTime.Now.AddDays(-1) }}; 
            yield return new object[] { new UpdateBookVM { AuthorId = 1,  PageCount= 120,GenreIds = new List<int>{1,2,3},PublishTime = DateTime.Now.AddDays(-1) }}; 
            yield return new object[] { new UpdateBookVM { AuthorId = 1, Title = "deneme", PageCount= 0,GenreIds = new List<int>{1,2,3},PublishTime = DateTime.Now.AddDays(-1) }}; 
            yield return new object[] { new UpdateBookVM { AuthorId = 1, Title = "deneme", GenreIds = new List<int>{1,2,3},PublishTime = DateTime.Now.AddDays(-1) }}; 
            yield return new object[] { new UpdateBookVM { AuthorId = 1, Title = "deneme", PageCount= 12,GenreIds = new List<int>{1,2,3},PublishTime = DateTime.Now }}; 
            yield return new object[] { new UpdateBookVM { AuthorId = 1, Title = "deneme", PageCount= 12,GenreIds = new List<int>{1,2,3} }}; 
            
            yield return new object[] { new UpdateBookVM { AuthorId = 1, Title = "deneme", PageCount= 12,GenreIds = new List<int>(), PublishTime = DateTime.Now.AddDays(-1) }}; 
            yield return new object[] { new UpdateBookVM { AuthorId = 1, Title = "deneme", PageCount= 12,GenreIds = new List<int>(){1,-2}, PublishTime = DateTime.Now.AddDays(-1) }};
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
