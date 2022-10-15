using System.Reflection;
using BookStore.WebApi.BookContext;
using BookStore.WebApi.Extensions;
using Microsoft.EntityFrameworkCore;
using BookStore.WebApi.Filters;
using FluentValidation.AspNetCore;
using BookStore.WebApi.Common.Validators;

var builder = WebApplication.CreateBuilder(args);

// Validation filter
builder.Services.AddControllers(options => options.Filters.Add<ValidationFilters>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<AddBookValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);
builder.Services.AddControllers();
builder.Services.AddDbContext<BookDBContext>(options => options.UseInMemoryDatabase(databaseName:"BookStoreDB"));
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(Program)));

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
