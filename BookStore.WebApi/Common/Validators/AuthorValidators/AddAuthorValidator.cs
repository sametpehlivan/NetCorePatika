using BookStore.WebApi.Application.AuthorOperation.Commands.AddAuthorCommands;
using FluentValidation;

namespace BookStore.WebApi.Common.Validators.AuthorValidators;

public class AddAuthorValidator : AbstractValidator<AddAuthorVM>
{
    public AddAuthorValidator()
    {
        RuleFor(author => author.FirstName).NotEmpty().NotNull().WithMessage("Isim  alanı gereklidir");
        RuleFor(author => author.LastName).NotEmpty().NotNull().WithMessage("Soy isim  alanı gereklidir");
        RuleFor(author => author.Birthday).NotEmpty().NotNull().WithMessage("Dogum Tarihi  alanı gereklidir");
        RuleFor(author => author.Birthday).Must(b =>  b.Date < DateTime.Now.Date.AddYears(-18) ).WithMessage("Gecersiz dogum tarihi");

          
    
    }
}