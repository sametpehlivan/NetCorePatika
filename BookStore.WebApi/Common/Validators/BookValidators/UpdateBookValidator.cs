
using BookStore.WebApi.Application.BookOperation.Commands.UpdateBookCommands;
using BookStore.WebApi.Extensions;
using FluentValidation;

namespace BookStore.WebApi.Common.Validators.BookValidators;

public class UpdateBookValidator: AbstractValidator<UpdateBookVM>
{
    public UpdateBookValidator()
    {
        //AuthorId
        RuleFor(ub => ub.AuthorId).NotNull().WithMessage("Bu alan bos olamaz");
        RuleFor(ub => ub.AuthorId).GreaterThan(0).WithMessage("Bu alan 0'dan buyuk olmali");
        //Title
        RuleFor(ab => ab.Title).NotEmpty().NotNull().WithMessage("Bu alan bos olamaz");
        //pagecount
        RuleFor(ab => ab.PageCount).NotNull().WithMessage("Bu alan bos olamaz");
        RuleFor(ab => ab.PageCount).GreaterThan(0).WithMessage("Bu alan 0'dan buyuk olmali");
        //publish date
        RuleFor(ab => ab.PublishTime).NotEmpty().NotNull().WithMessage("Tarih alanı gereklidir");
        RuleFor(ab => ab.PublishTime).LessThan(DateTime.Now.Date).WithMessage("Hatali tarih");
        //GenreId
        RuleFor(ab => ab.GenreIds).ListMustContainMoreThan(0).WithMessage("En az bir tane kaetgori secilmeli");
        RuleFor(ab => ab.GenreIds).Must(ab => (ab.Where(x => x > 0).Count() == ab.Count())).WithMessage("Gecersiz kategori Id");
    
    }
}
