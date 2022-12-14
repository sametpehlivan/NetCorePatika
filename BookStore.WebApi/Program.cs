using System.Reflection;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;
using BookStore.WebApi.Filters;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Validation filter
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilters>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<Program>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddDbContext<BookDBContext>(options => options.UseInMemoryDatabase(databaseName:"BookStoreDB"));
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Program)));
builder.Services.AddScoped<IBookDBContext,BookDBContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();
await app.SeedDataInMemory();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseException();
app.Run();
