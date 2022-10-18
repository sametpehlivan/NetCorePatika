using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BookStore.WebApi.Application.BookOperation.Commands.AddBookCommands;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Validators.BookValidators;
using BookStore.WebApi.Entities;
using FluentAssertions;
using TestSetup;
using Xunit;

namespace Application.BookOperation.Commands;
public class AddBookCommandValidatorTest :IClassFixture<CommonTestFixture>
{
    [Theory]
    [ClassData(typeof(InValiDataGenerator))]
    public void WhenInvalidInput_Validator_ShouldBeReturnedErrors(AddBookVM model)
    {
              
            AddBookValidator validator = new AddBookValidator();
            var errors = validator.Validate(model);
            errors.Errors.Count.Should().BeGreaterThan(0);
    }

}
public class InValiDataGenerator : IEnumerable<object[]>
{

    public  IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]{ new AddBookVM { AuthorId = 0, Title = null, PageCount = 0 , GenreIds =  new List<int>(),PublishTime = DateTime.Now } };
        yield return new object[]{ new AddBookVM { AuthorId = 1, Title = null, PageCount = 0 , GenreIds =  new List<int>(),PublishTime = DateTime.Now } };
        yield return new object[]{ new AddBookVM { AuthorId = 1, Title = "", PageCount = 0 , GenreIds =  new List<int>(),PublishTime = DateTime.Now } };
        yield return new object[]{ new AddBookVM { AuthorId = 1, Title = "deneme", PageCount = 0 , GenreIds =  new List<int>(),PublishTime = DateTime.Now } };
        yield return new object[]{ new AddBookVM { AuthorId = 1, Title = "deneme", PageCount = 1 , GenreIds =  new List<int>(),PublishTime = DateTime.Now } };
      
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class ValiDataGenerator : IEnumerable<object[]>
{

    public  IEnumerator<object[]> GetEnumerator()
    {
      
        yield return new object[]{ new AddBookVM { AuthorId = 0, Title = "deneme", PageCount = 1 , GenreIds =  new List<int>(){1,2},PublishTime = DateTime.Now.AddDays(-1) } };
         yield return new object[]{ new AddBookVM {  Title = "deneme", PageCount = 1 , GenreIds =  new List<int>(){1,2},PublishTime = DateTime.Now.AddDays(-1) } };
      
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}