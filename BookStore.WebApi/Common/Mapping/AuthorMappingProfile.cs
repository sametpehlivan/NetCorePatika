
using AutoMapper;
using BookStore.WebApi.Application.AuthorOperation.Commands.AddAuthorCommands;
using BookStore.WebApi.Application.AuthorOperation.Queries.GetAuthorQueries;
using BookStore.WebApi.Application.AuthorOperation.Queries.GetAuthorsQueries;
using BookStore.WebApi.Entities;

namespace BookStore.WebApi.Common.Mapping;

public class AuthorMappingProfile : Profile 
{
    public AuthorMappingProfile()
    {   //get authors
        CreateMap<Author,GetAuthorsVM>().ForMember(ga => ga.Books,a => a.MapFrom(a => a.Books.Select(b => b.Title).ToList()));
        //get author
        CreateMap<Author,GetAuthorVM>().ForMember(ga => ga.Books,a => a.MapFrom(a => a.Books.Select(b => b.Title).ToList()));
        //add author
        CreateMap<AddAuthorVM,Author>();
        //update author
    }
}