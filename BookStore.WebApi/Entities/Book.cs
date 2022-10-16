using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.WebApi.Entities;

public class Book
{

  [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
  public int Id {get; set;}
  public int AuthorId {get; set;}
  public string Title { get; set; }  
  public int PageCount { get; set; }
  public DateTime PublishTime {get; set;}
  public  Author Author {get; set;}
  public  List<BookGenre> BookGenres {get; set;}
}