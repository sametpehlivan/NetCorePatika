
using BookStore.WebApi.BookOperation.Commands.UpdateBookCommands;
using FluentValidation;

namespace BookStore.WebApi.Common.Validators;

public class UpdateBookValidator: AbstractValidator<UpdateBookVM>
{
    public UpdateBookValidator()
    {
        //Title
        RuleFor(ub => ub.Title).NotEmpty().NotNull().WithMessage("Bu alan boş olamaz");
        //genreId
        RuleFor(ub => ub.GenreId).NotNull().WithMessage("Bu alan boş olamaz");
        RuleFor(ub => ub.GenreId).GreaterThan(0).WithMessage("Bu alan 0'dan büyük olmalı");
        //pagecount
        RuleFor(ub => ub.PageCount).NotNull().WithMessage("Bu alan boş olamaz");
        RuleFor(ub => ub.PageCount).GreaterThan(0).WithMessage("Bu alan 0'dan büyük olmalı");
        //publish date
        RuleFor(ub => ub.PublishTime).NotNull().LessThanOrEqualTo(DateTime.Now).WithMessage("Hatalı tarih");

    }
}
