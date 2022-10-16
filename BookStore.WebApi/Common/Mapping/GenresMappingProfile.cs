using AutoMapper;
using BookStore.WebApi.Entities;
using BookStore.WebApi.GenreOperation.Commands.AddGenreCommands;
using BookStore.WebApi.GenreOperation.Commands.UpdateGenreCommands;
using BookStore.WebApi.GenreOperation.GetGenreQueries;
using BookStore.WebApi.GenreOperation.GetGenresQueries;

namespace BookStore.WebApi.Common.Mapping;

public class GenresMappingProfile : Profile
{
    public GenresMappingProfile()
    {   //get genres
        CreateMap<Genre,GetGenresVM>()
            .ForMember(getGenres => getGenres.Books,a => a.MapFrom(a => a.BookGenres.Select(a => a.Book.Title).ToList()));
        //get genre
        CreateMap<Genre,GetGenreVM>()
            .ForMember(getGenre => getGenre.Books,a => a.MapFrom(a => a.BookGenres.Select(a => a.Book.Title).ToList()));
        //add genre
        CreateMap<AddGenreVM,Genre>();
        CreateMap<UpdateGenreVM,Genre>();
    }   
}