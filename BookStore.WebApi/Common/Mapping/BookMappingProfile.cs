using AutoMapper;
using BookStore.WebApi.Application.BookOperation.Commands.AddBookCommands;
using BookStore.WebApi.Application.BookOperation.Commands.UpdateBookCommands;
using BookStore.WebApi.Application.BookOperation.Queries.GetBookQueries;
using BookStore.WebApi.Application.BookOperation.Queries.GetBooksQueries;
using BookStore.WebApi.Entities;

namespace BookStore.WebApi.Common.Mapping;

public class BookMappingProfile : Profile 
{
    public BookMappingProfile()
    {
        
        //for GetBooksQuery
        
        CreateMap<Book,GetBooksVM>()
            .ForMember(gb => gb.AuthorName,b => b.MapFrom(b => (b.Author.FirstName + " " +b.Author.LastName )))
            .ForMember(gb => gb.Genres,b => b.MapFrom(b => b.BookGenres.Select(ab => ab.Genre.Name).ToList() ));
        //for GetBookQuery
        CreateMap<Book,GetBookVM>()
            .ForMember(gb => gb.AuthorName,b => b.MapFrom(b => (b.Author.FirstName + " " +b.Author.LastName )))
            .ForMember(gb => gb.Genres,b => b.MapFrom(b => b.BookGenres.Select(ab =>  ab.Genre.Name).ToList() ));
        //for AddBookCommand
        CreateMap<AddBookVM,Book>();
        CreateMap<Book,AddBookVM>();
        //for Update
     
        CreateMap<UpdateBookVM,Book>();
        CreateMap<Book,UpdateBookVM>();    
        
        
    }
}