using BookStore.WebApi.BookOperation.Commands.AddBookCommands;
using FluentValidation;

namespace BookStore.WebApi.Common.Validators;

public class AddBookValidator: AbstractValidator<AddBookVM>
{
    public AddBookValidator()
    {
        //Title
        RuleFor(ab => ab.Title).NotEmpty().NotNull().WithMessage("Bu alan boş olamaz");
        //genreId
        RuleFor(ab => ab.GenreId).NotNull().WithMessage("Bu alan boş olamaz");
        RuleFor(ab => ab.GenreId).GreaterThan(0).WithMessage("Bu alan 0'dan büyük olmalı");
        //pagecount
        RuleFor(ab => ab.PageCount).NotNull().WithMessage("Bu alan boş olamaz");
        RuleFor(ab => ab.PageCount).GreaterThan(0).WithMessage("Bu alan 0'dan büyük olmalı");
        //publish date
        RuleFor(ab => ab.PublishTime).NotNull().LessThanOrEqualTo(DateTime.Now).WithMessage("Hatalı tarih");

    }
}
