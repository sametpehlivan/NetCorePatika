using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.AuthorOperation.Commands.AddAuthorCommands;

public class AddAuthorCommand
{
    BookDBContext _context;
    IMapper _mapper;
    public AddAuthorCommand(BookDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task handleAsync(AddAuthorVM model)
    {   
        var author = await _context.Authors
            .Where(a => a.FirstName.Trim().ToLower() == model.FirstName.Trim().ToLower() && a.LastName.Trim().ToLower() == model.LastName.Trim().ToLower()).FirstOrDefaultAsync();
        if(author != null)
            throw new Exception("yazar mevcut");
        author = _mapper.Map<Author>(model);
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
    }
}
public class AddAuthorVM
{
    public string? FirstName {get; set;}
    public string? LastName {get; set;}
    public DateTime Birthday {get; set;}
}