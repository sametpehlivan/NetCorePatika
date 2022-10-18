using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestSetup;
public static class Books
{
    public static void AddBooks(this BookDBContext context)
    {
        context.Books.AddRange(new List<Book>
            {
                new Book { Title = "Kitap1", PageCount = 471, AuthorId = 1, PublishTime = new DateTime(1946,4,13) },
                new Book { Title = "Kitap1.2", PageCount = 471, AuthorId = 1, PublishTime = new DateTime(1946,4,13) },
                new Book { Title = "Kitap2", PageCount = 221, AuthorId = 2, PublishTime = new DateTime(1949,4,15) },
                new Book { Title = "Kitap2.2", PageCount = 221, AuthorId = 2, PublishTime = new DateTime(1949,4,15) },
                new Book { Title = "Kitap2.3", PageCount = 221, AuthorId = 2,  PublishTime = new DateTime(1949,4,15) },
                new Book { Title = "Kitap3", PageCount = 221, AuthorId = 3, PublishTime = new DateTime(1949,4,15) },
                new Book { Title = "Bozkurtlar Diriliyor", PageCount = 221, AuthorId = 4, PublishTime = new DateTime(1949,4,15) },
            });
      

    }
}