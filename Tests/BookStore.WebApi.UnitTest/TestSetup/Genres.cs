using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestSetup;
public static class Genres
{
    public static void AddGenres(this BookDBContext context)
    {
       
            context.Genres.AddRange(new List<Genre>()
            {
                new Genre() { Name = "Fantasy" },
                new Genre() { Name = "Historical Fiction" },
                new Genre() { Name = "Romance" }
            });
        

    }
}