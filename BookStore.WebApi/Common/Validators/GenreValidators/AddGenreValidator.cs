using BookStore.WebApi.Application.GenreOperation.Commands.AddGenreCommands;
using FluentValidation;

namespace BookStore.WebApi.Common.Validators.GenreValidator;

public class AddGenreValidator : AbstractValidator<AddGenreVM>
{
    public AddGenreValidator()
    {
        RuleFor(a => a.Name).NotNull().NotEmpty().WithMessage("kategori için Alan bilgisini girmelisiniz");
    }
}