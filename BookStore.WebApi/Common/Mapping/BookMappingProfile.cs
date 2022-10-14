using AutoMapper;
using BookStore.WebApi.BookOperation.Commands.AddBookCommands;
using BookStore.WebApi.BookOperation.Commands.UpdateBookCommands;
using BookStore.WebApi.BookOperation.Queries.GetBookQueries;
using BookStore.WebApi.BookOperation.Queries.GetBooksQueries;
using BookStore.WebApi.Common.Enums;

namespace BookStore.WebApi.Common.Mapping;

public class BookMappingProfile : Profile 
{
    public BookMappingProfile()
    {
        
        //for GetBooksQuery
        CreateMap<GetBooksVM,Book>()
            .ForMember(b => b.GenreId, gb => gb.MapFrom(gb =>  (int)(Enum.Parse<GenreEnum>(gb.Genre))));
        CreateMap<Book,GetBooksVM>()
            .ForMember(gb => gb.Genre, b => b.MapFrom(b => ((GenreEnum)b.GenreId).ToString()));
        //for GetBookQuery
        CreateMap<GetBookVM,Book>()
            .ForMember(b => b.GenreId, gb => gb.MapFrom(gb =>  (int)(Enum.Parse<GenreEnum>(gb.Genre))));
        CreateMap<Book,GetBookVM>()
            .ForMember(gb => gb.Genre, b => b.MapFrom(b => ((GenreEnum)b.GenreId).ToString()));
        //for AddBookCommand
        CreateMap<AddBookVM,Book>();
        CreateMap<Book,AddBookVM>();
        //for Update
     
        CreateMap<UpdateBookVM,Book>();
        CreateMap<Book,UpdateBookVM>();    
        
        
    }
}