using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestSetup;
public static class BooksGenres
{
    public static void AddBookGenre(this BookDBContext context)
    {
       
            context.BookGenres.AddRange(new List<BookGenre>(){
                new BookGenre { BookId=1, GenreId=1 },
                new BookGenre { BookId=1, GenreId=2 },
                new BookGenre { BookId=1, GenreId=3 },
                new BookGenre { BookId=2, GenreId=1 }, 
                new BookGenre { BookId=2, GenreId=2 }, 
                new BookGenre { BookId=3, GenreId=3 }, 
                new BookGenre { BookId=4, GenreId=3 }, 
                new BookGenre { BookId=5, GenreId=2 },
                new BookGenre { BookId=6, GenreId=1 },
                new BookGenre { BookId=7, GenreId=1 },
            });
        

    }
}