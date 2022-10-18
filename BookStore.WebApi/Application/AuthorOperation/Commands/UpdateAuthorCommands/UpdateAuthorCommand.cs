using AutoMapper;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookStore.WebApi.Application.AuthorOperation.Commands.UpdateAuthorCommands;

public class UpdateAuthorCommand
{
    IBookDBContext _context;
    IMapper _mapper;
    public UpdateAuthorCommand(IBookDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task handleAsync(int id,UpdateAuthorVM model)
    {   
        var author = await _context.Authors.Where(a => a.Id == id).FirstOrDefaultAsync();
        if(author == null)
            throw new Exception("yazar mevcut değil");
            
        author = _mapper.Map<UpdateAuthorVM,Author>(model,destination:author);
        _context.Authors.Update(author);
        await _context.SaveChangesAsync();
    }
}
public class UpdateAuthorVM
{
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public DateTime Birthday {get; set;}
}