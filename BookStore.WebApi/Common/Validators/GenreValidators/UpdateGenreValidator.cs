
using BookStore.WebApi.Application.GenreOperation.Commands.UpdateGenreCommands;
using FluentValidation;

namespace BookStore.WebApi.Common.Validators.GenreValidator;

public class UpdateGenreValidator : AbstractValidator<UpdateGenreVM>
{
    public UpdateGenreValidator()
    {
        RuleFor(a => a.Name).NotNull().NotEmpty().WithMessage("kategori için Alan bilgisini girmelisiniz");
    }
}