using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.WebApi.Entities;
public class Genre
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get; set;}
    public string Name {get; set;}
    public  List<BookGenre> BookGenres {get; set;}
}