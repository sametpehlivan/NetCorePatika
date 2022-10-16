using System.ComponentModel.DataAnnotations.Schema;

namespace BookStore.WebApi.Entities;

public class Author 
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id  {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public DateTime Birthday {get; set;}
    public  List<Book> Books {get; set;}
}