using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Common.Enums;
using Microsoft.EntityFrameworkCore;
using BookStore.WebApi.Entities;

namespace BookStore.WebApi.BookOperation.Commands.UpdateBookCommands;


public class UpdateBookCommand
{
    private readonly BookDBContext _context;
    private readonly IMapper _mapper;
    public UpdateBookCommand(BookDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }
    public async Task handleAsync(UpdateBookVM model, int id)
    {

        var book = _context.Books.AsQueryable().Include(b => b.BookGenres).FirstOrDefault(b => b.Id == id);
        if (book == null) throw new Exception("Not found book");
        if(await _context.Genres.Where( g => model.GenreIds.Contains(g.Id)).CountAsync() != model.GenreIds.Count()) throw new  Exception("Kategori Id bulunamadı");
        if(await _context.Authors.FindAsync(model.AuthorId) == null ) throw new  Exception("Yazar mevcut degil"); 
       
        book = _mapper.Map<UpdateBookVM, Book>(model, destination: book);
      
        book.BookGenres = model.GenreIds.Select(g => new BookGenre()
        {
            BookId = book.Id,
            GenreId = g
        }).ToList();
        _context.Update(book);
        await _context.SaveChangesAsync();
    }
}

public class UpdateBookVM
{
    public int AuthorId { get; set; }
    public string Title { get; set; }
    public int PageCount { get; set; }
    public List<int> GenreIds { get; set; }
    public DateTime PublishTime { get; set; }
}
