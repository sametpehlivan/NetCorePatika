using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestSetup;
public static class Authors
{
    public static void AddAuthors(this BookDBContext context)
    {
      
        context.Authors.AddRange(new List<Author>{
            new Author() { FirstName ="Yazar", LastName="Bir", Birthday = DateTime.Now.AddYears(-50) },
            new Author() { FirstName ="Yazar", LastName="Iki", Birthday = DateTime.Now.AddYears(-40) },
            new Author() { FirstName ="Yazar", LastName="Uc",  Birthday = DateTime.Now.AddYears(-38) },
            new Author() { FirstName ="Yazar", LastName = "Atsiz", Birthday = new DateTime(19,1,12)  },  
        });
        
        
    }
}