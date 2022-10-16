using BookStore.WebApi.BookOperation.Commands.AddBookCommands;
using BookStore.WebApi.Extensions;
using FluentValidation;

namespace BookStore.WebApi.Common.Validators.BookValidators;

public class AddBookValidator: AbstractValidator<AddBookVM>
{
    public AddBookValidator()
    {
        //AuthorId
        RuleFor(ub => ub.AuthorId).NotNull().WithMessage("Bu alan boş olamaz");
        RuleFor(ub => ub.AuthorId).GreaterThan(0).WithMessage("Bu alan 0'dan büyük olmalı");
        //Title
        RuleFor(ab => ab.Title).NotEmpty().NotNull().WithMessage("Bu alan bos olamaz");
        //pagecount
        RuleFor(ab => ab.PageCount).NotNull().WithMessage("Bu alan bos olamaz");
        RuleFor(ab => ab.PageCount).GreaterThan(0).WithMessage("Bu alan 0'dan buyuk olmali");
        //publish date
        RuleFor(ab => ab.PublishTime).NotNull().LessThanOrEqualTo(DateTime.Now).WithMessage("Hatali tarih");
        //GenreId
        RuleFor(ab => ab.GenreIds).ListMustContainMoreThan(0).WithMessage("En az bir tane Genre secilmeli");
        RuleFor(ab => ab.GenreIds).Must(ab => (ab.Where(x => x > 0).Count() == ab.Count())).WithMessage("Gecersiz Id");

    }
}
