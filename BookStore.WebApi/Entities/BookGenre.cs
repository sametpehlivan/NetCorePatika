using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.WebApi.Entities;
public class BookGenre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}
    public int BookId {get; set;}
    public int GenreId {get; set;}
    public  Book Book {get; set;}
    public  Genre Genre {get; set;}
    
}