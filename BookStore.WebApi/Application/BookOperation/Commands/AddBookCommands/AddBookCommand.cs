using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using Microsoft.EntityFrameworkCore;
using BookStore.WebApi.Entities;

namespace BookStore.WebApi.Application.BookOperation.Commands.AddBookCommands;


public class AddBookCommand 
{
    private readonly IBookDBContext _context;
    private readonly IMapper _mapper;
    public AddBookCommand(IBookDBContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task handleAsync(AddBookVM model)
    {

        if(await _context.Books.AnyAsync(b => b.Title.Trim().ToLower() == model.Title.Trim().ToLower() && b.AuthorId == model.AuthorId )) throw new  Exception("Kitap Mevcut");
        if(await _context.Genres.Where( g => model.GenreIds.Contains(g.Id)).CountAsync() != model.GenreIds.Count()) throw new  Exception("Kategori Id bulunamadı");
        if(await _context.Authors.FindAsync(model.AuthorId) == null ) throw new  Exception("Yazar mevcut degil");
        var yazar = await _context.Authors.FindAsync(model.AuthorId) ;
        var book = _mapper.Map<Book>(model);
        
        book.BookGenres =  model.GenreIds.Select(g => new BookGenre(){
                BookId = book.Id,
                GenreId = g
        }).ToList();

        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
        
    }
}

public class AddBookVM
{
  public int AuthorId { get; set; }
  public string Title { get; set; }  
  public int PageCount { get; set; }
  public  List<int> GenreIds {get; set;}
  public DateTime PublishTime {get; set;}
}